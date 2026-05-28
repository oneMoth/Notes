using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Notes
{
    public partial class Form1 : Form
    {
        private List<Note> notes;
        private BindingSource bindingSource;
        private Timer reminderTimer;
        private HashSet<string> remindedNotes = new HashSet<string>();

        public Form1()
        {
            InitializeComponent();
            notes = DataManager.Load();
            bindingSource = new BindingSource();

            cmbFilterPriority.Items.Add("Все");
            cmbFilterPriority.Items.Add("Высокий");
            cmbFilterPriority.Items.Add("Средний");
            cmbFilterPriority.Items.Add("Низкий");
            cmbFilterPriority.SelectedIndex = 0;

            InitDgv();
            ApplyFilter();
            UpdateStatusBar();

            reminderTimer = new Timer();
            reminderTimer.Interval = 60000;
            reminderTimer.Tick += ReminderTimer_Tick;
            reminderTimer.Start();

            timerStatusUpdate.Start();

            Logger.Log("Запуск приложения");
        }

        private void InitDgv()
        {
            dgvNotes.AutoGenerateColumns = false;
            dgvNotes.DataSource = bindingSource;

            dgvNotes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Title", HeaderText = "Название", Width = 200 });
            dgvNotes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReminderDate", HeaderText = "Время", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy HH:mm" } });
            dgvNotes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Priority", HeaderText = "Приоритет", Width = 100 });

            var statusCol = new DataGridViewTextBoxColumn
            {
                HeaderText = "Статус",
                Width = 100
            };
            dgvNotes.Columns.Add(statusCol);

            dgvNotes.CellFormatting += DgvNotes_CellFormatting;
        }

        private void DgvNotes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNotes.Rows.Count)
            {
                var note = dgvNotes.Rows[e.RowIndex].DataBoundItem as Note;
                if (note != null)
                {
                    if (dgvNotes.Columns[e.ColumnIndex].HeaderText == "Статус")
                    {
                        e.Value = note.IsCompleted ? "Выполнено" : "Не выполнено";
                    }

                    if (note.IsCompleted)
                    {
                        dgvNotes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                        dgvNotes.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGray;
                    }
                    else
                    {
                        if (note.Priority == "Высокий")
                            dgvNotes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
                        else if (note.Priority == "Средний")
                            dgvNotes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                        else
                            dgvNotes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;

                        dgvNotes.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void ApplyFilter()
        {
            var filtered = notes.AsEnumerable();

            string prio = cmbFilterPriority.SelectedItem?.ToString();
            if (prio != "Все" && !string.IsNullOrEmpty(prio))
            {
                filtered = filtered.Where(n => n.Priority == prio);
            }

            if (chkOnlyIncomplete.Checked)
            {
                filtered = filtered.Where(n => !n.IsCompleted);
            }

            string search = txtSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(search))
            {
                filtered = filtered.Where(n => n.Title.ToLower().Contains(search));
            }

            bindingSource.DataSource = filtered.ToList();
            UpdateStatusBar();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                notes.Add(form2.CurrentNote);
                Logger.Log($"Добавление заметки: {form2.CurrentNote.Title}");
                SaveData();
                ApplyFilter();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is Note currentNote)
            {
                string oldData = $"{currentNote.Title} | {currentNote.Priority}";
                var form2 = new Form2(currentNote);
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    Logger.Log($"Редактирование заметки. Старые: {oldData}, Новые: {form2.CurrentNote.Title} | {form2.CurrentNote.Priority}");
                    SaveData();
                    ApplyFilter();
                    dgvNotes.Refresh();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is Note currentNote)
            {
                if (MessageBox.Show("Удалить заметку?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    notes.Remove(currentNote);
                    Logger.Log($"Удаление заметки: {currentNote.Title}");
                    SaveData();
                    ApplyFilter();
                }
            }
        }

        private void btnDeleteCompleted_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить все выполненные заметки?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int count = notes.RemoveAll(n => n.IsCompleted);
                if (count > 0)
                {
                    Logger.Log($"Удаление выполненных заметок (количество: {count})");
                    SaveData();
                    ApplyFilter();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            notes = DataManager.Load();
            ApplyFilter();
        }

        private void cmbFilterPriority_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();
        private void chkOnlyIncomplete_CheckedChanged(object sender, EventArgs e) => ApplyFilter();
        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilter();

        private void SaveData()
        {
            DataManager.Save(notes);
        }

        private void UpdateStatusBar()
        {
            lblNotesCount.Text = $"Заметок: {notes.Count}";
            lblFilePath.Text = $"Файл: {System.IO.Path.GetFullPath(DataManager.FilePath)}";
        }

        private void timerStatusUpdate_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }

        private void ReminderTimer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            foreach (var note in notes)
            {
                if (!note.IsCompleted && note.ReminderDate <= now && !remindedNotes.Contains(note.Id))
                {
                    remindedNotes.Add(note.Id);
                    Logger.Log($"Срабатывание напоминания: {note.Title}");
                    MessageBox.Show($"Напоминание: {note.Title}\n{note.Text}", "Напоминание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
