
namespace MenuStrip
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.NewTaskStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.TasksStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AddTaskStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EditTaskStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTaskStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ListBoxTasks = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileStripMenu,
            this.TasksStripMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileStripMenu
            // 
            this.FileStripMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.FileStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewTaskStripMenu,
            this.ExitStripMenu,
            this.AboutStripMenu});
            this.FileStripMenu.Name = "FileStripMenu";
            this.FileStripMenu.Size = new System.Drawing.Size(37, 20);
            this.FileStripMenu.Text = "File";
            // 
            // NewTaskStripMenu
            // 
            this.NewTaskStripMenu.Name = "NewTaskStripMenu";
            this.NewTaskStripMenu.Size = new System.Drawing.Size(123, 22);
            this.NewTaskStripMenu.Text = "New Task";
            this.NewTaskStripMenu.Click += new System.EventHandler(this.NewTaskStripMenu_Click);
            // 
            // ExitStripMenu
            // 
            this.ExitStripMenu.Name = "ExitStripMenu";
            this.ExitStripMenu.Size = new System.Drawing.Size(123, 22);
            this.ExitStripMenu.Text = "Exit";
            // 
            // AboutStripMenu
            // 
            this.AboutStripMenu.Name = "AboutStripMenu";
            this.AboutStripMenu.Size = new System.Drawing.Size(123, 22);
            this.AboutStripMenu.Text = "About";
            this.AboutStripMenu.Click += new System.EventHandler(this.AboutStripMenu_Click);
            // 
            // TasksStripMenu
            // 
            this.TasksStripMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TasksStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTaskStripMenu,
            this.EditTaskStripMenu,
            this.DeleteTaskStripMenu});
            this.TasksStripMenu.Name = "TasksStripMenu";
            this.TasksStripMenu.Size = new System.Drawing.Size(46, 20);
            this.TasksStripMenu.Text = "Tasks";
            // 
            // AddTaskStripMenu
            // 
            this.AddTaskStripMenu.Name = "AddTaskStripMenu";
            this.AddTaskStripMenu.Size = new System.Drawing.Size(132, 22);
            this.AddTaskStripMenu.Text = "Add Task";
            this.AddTaskStripMenu.Click += new System.EventHandler(this.AddTaskStripMenu_Click);
            // 
            // EditTaskStripMenu
            // 
            this.EditTaskStripMenu.Name = "EditTaskStripMenu";
            this.EditTaskStripMenu.Size = new System.Drawing.Size(132, 22);
            this.EditTaskStripMenu.Text = "Edit Task";
            this.EditTaskStripMenu.Click += new System.EventHandler(this.EditTaskStripMenu_Click);
            // 
            // DeleteTaskStripMenu
            // 
            this.DeleteTaskStripMenu.Name = "DeleteTaskStripMenu";
            this.DeleteTaskStripMenu.Size = new System.Drawing.Size(132, 22);
            this.DeleteTaskStripMenu.Text = "Delete Task";
            this.DeleteTaskStripMenu.Click += new System.EventHandler(this.DeleteTaskStripMenu_Click);
            // 
            // ListBoxTasks
            // 
            this.ListBoxTasks.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ListBoxTasks.FormattingEnabled = true;
            this.ListBoxTasks.Location = new System.Drawing.Point(33, 50);
            this.ListBoxTasks.Name = "ListBoxTasks";
            this.ListBoxTasks.Size = new System.Drawing.Size(704, 355);
            this.ListBoxTasks.TabIndex = 1;
            this.ListBoxTasks.SelectedIndexChanged += new System.EventHandler(this.ListBoxTasks_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ListBoxTasks);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileStripMenu;
        private System.Windows.Forms.ToolStripMenuItem NewTaskStripMenu;
        private System.Windows.Forms.ToolStripMenuItem ExitStripMenu;
        private System.Windows.Forms.ToolStripMenuItem TasksStripMenu;
        private System.Windows.Forms.ToolStripMenuItem AddTaskStripMenu;
        private System.Windows.Forms.ToolStripMenuItem EditTaskStripMenu;
        private System.Windows.Forms.ToolStripMenuItem DeleteTaskStripMenu;
        private System.Windows.Forms.ListBox ListBoxTasks;
        private System.Windows.Forms.ToolStripMenuItem AboutStripMenu;
    }
}

