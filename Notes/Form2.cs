using System;
using System.Windows.Forms;

namespace Notes
{
    public partial class Form2 : Form
    {
        public Note CurrentNote { get; private set; }

        public Form2(Note note = null)
        {
            InitializeComponent();
            CurrentNote = note;

            cmbPriority.Items.Add("Высокий");
            cmbPriority.Items.Add("Средний");
            cmbPriority.Items.Add("Низкий");
            cmbPriority.SelectedIndex = 1;

            if (CurrentNote != null)
            {
                txtTitle.Text = CurrentNote.Title;
                dtpReminder.Value = CurrentNote.ReminderDate < dtpReminder.MinDate ? dtpReminder.MinDate : CurrentNote.ReminderDate;
                cmbPriority.SelectedItem = CurrentNote.Priority;
                chkCompleted.Checked = CurrentNote.IsCompleted;
                rtbText.Text = CurrentNote.Text;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Название заметки не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpReminder.Value < DateTime.Now)
            {
                var res = MessageBox.Show("Дата напоминания уже прошла. Сохранить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                    return;
            }

            if (CurrentNote == null)
            {
                CurrentNote = new Note();
            }

            CurrentNote.Title = txtTitle.Text;
            CurrentNote.ReminderDate = dtpReminder.Value;
            CurrentNote.Priority = cmbPriority.SelectedItem.ToString();
            CurrentNote.IsCompleted = chkCompleted.Checked;
            CurrentNote.Text = rtbText.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
