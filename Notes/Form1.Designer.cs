namespace Notes
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvNotes = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeleteCompleted = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.chkOnlyIncomplete = new System.Windows.Forms.CheckBox();
            this.cmbFilterPriority = new System.Windows.Forms.ComboBox();
            this.lblFilterPriority = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblCurrentTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNotesCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFilePath = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerStatusUpdate = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotes)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvNotes
            // 
            this.dgvNotes.AllowUserToAddRows = false;
            this.dgvNotes.AllowUserToDeleteRows = false;
            this.dgvNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNotes.Location = new System.Drawing.Point(0, 77);
            this.dgvNotes.Name = "dgvNotes";
            this.dgvNotes.ReadOnly = true;
            this.dgvNotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotes.Size = new System.Drawing.Size(800, 319);
            this.dgvNotes.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnDeleteCompleted);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 42);
            this.panel1.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(546, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Обновить список";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDeleteCompleted
            // 
            this.btnDeleteCompleted.Location = new System.Drawing.Point(368, 10);
            this.btnDeleteCompleted.Name = "btnDeleteCompleted";
            this.btnDeleteCompleted.Size = new System.Drawing.Size(162, 23);
            this.btnDeleteCompleted.TabIndex = 3;
            this.btnDeleteCompleted.Text = "Удалить все выполненные";
            this.btnDeleteCompleted.UseVisualStyleBackColor = true;
            this.btnDeleteCompleted.Click += new System.EventHandler(this.btnDeleteCompleted_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(269, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(145, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(107, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(17, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.lblSearch);
            this.panel2.Controls.Add(this.chkOnlyIncomplete);
            this.panel2.Controls.Add(this.cmbFilterPriority);
            this.panel2.Controls.Add(this.lblFilterPriority);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 35);
            this.panel2.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(479, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(187, 20);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(423, 9);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(42, 13);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = "Поиск:";
            // 
            // chkOnlyIncomplete
            // 
            this.chkOnlyIncomplete.AutoSize = true;
            this.chkOnlyIncomplete.Location = new System.Drawing.Point(219, 8);
            this.chkOnlyIncomplete.Name = "chkOnlyIncomplete";
            this.chkOnlyIncomplete.Size = new System.Drawing.Size(186, 17);
            this.chkOnlyIncomplete.TabIndex = 2;
            this.chkOnlyIncomplete.Text = "Показать только невыполненные";
            this.chkOnlyIncomplete.UseVisualStyleBackColor = true;
            this.chkOnlyIncomplete.CheckedChanged += new System.EventHandler(this.chkOnlyIncomplete_CheckedChanged);
            // 
            // cmbFilterPriority
            // 
            this.cmbFilterPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterPriority.FormattingEnabled = true;
            this.cmbFilterPriority.Location = new System.Drawing.Point(67, 6);
            this.cmbFilterPriority.Name = "cmbFilterPriority";
            this.cmbFilterPriority.Size = new System.Drawing.Size(121, 21);
            this.cmbFilterPriority.TabIndex = 1;
            this.cmbFilterPriority.SelectedIndexChanged += new System.EventHandler(this.cmbFilterPriority_SelectedIndexChanged);
            // 
            // lblFilterPriority
            // 
            this.lblFilterPriority.AutoSize = true;
            this.lblFilterPriority.Location = new System.Drawing.Point(14, 9);
            this.lblFilterPriority.Name = "lblFilterPriority";
            this.lblFilterPriority.Size = new System.Drawing.Size(47, 13);
            this.lblFilterPriority.TabIndex = 0;
            this.lblFilterPriority.Text = "Фильтр:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCurrentTime,
            this.lblNotesCount,
            this.lblFilePath});
            this.statusStrip1.Location = new System.Drawing.Point(0, 396);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.AutoSize = false;
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(150, 17);
            this.lblCurrentTime.Text = "Время";
            this.lblCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNotesCount
            // 
            this.lblNotesCount.AutoSize = false;
            this.lblNotesCount.Name = "lblNotesCount";
            this.lblNotesCount.Size = new System.Drawing.Size(120, 17);
            this.lblNotesCount.Text = "Заметок: 0";
            this.lblNotesCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFilePath
            // 
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(515, 17);
            this.lblFilePath.Spring = true;
            this.lblFilePath.Text = "Файл:";
            this.lblFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerStatusUpdate
            // 
            this.timerStatusUpdate.Interval = 1000;
            this.timerStatusUpdate.Tick += new System.EventHandler(this.timerStatusUpdate_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 418);
            this.Controls.Add(this.dgvNotes);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Менеджер личных заметок с напоминаниями";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dgvNotes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDeleteCompleted;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.CheckBox chkOnlyIncomplete;
        private System.Windows.Forms.ComboBox cmbFilterPriority;
        private System.Windows.Forms.Label lblFilterPriority;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentTime;
        private System.Windows.Forms.ToolStripStatusLabel lblNotesCount;
        private System.Windows.Forms.ToolStripStatusLabel lblFilePath;
        private System.Windows.Forms.Timer timerStatusUpdate;
    }
}
