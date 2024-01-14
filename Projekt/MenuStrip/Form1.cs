using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MenuStrip
{
    public partial class Form1 : Form
    {
        private const string Filename = "tasks.json";

        private List<Task> tasks = new List<Task>();

        public Form1()
        {
            InitializeComponent();
            LoadTasks();
        }

        private void NewTaskStripMenu_Click(object sender, EventArgs e)
        {
            CreateNewTask();
            RefreshTaskList();
            SaveTasks();
        }

        private void AddTaskStripMenu_Click(object sender, EventArgs e)
        {
            CreateNewTask();
            RefreshTaskList();
            SaveTasks();
        }

        private void ListBoxTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isTaskSelected = ListBoxTasks.SelectedIndex != -1;
            EditTaskStripMenu.Enabled = isTaskSelected;
            DeleteTaskStripMenu.Enabled = isTaskSelected;
        }

        private void EditTaskStripMenu_Click(object sender, EventArgs e)
        {
            int selectedIndex = ListBoxTasks.SelectedIndex;
            if (selectedIndex != -1)
            {
                Task selectedTask = tasks[selectedIndex];
                EditTask(selectedTask);
                RefreshTaskList();
                SaveTasks();
            }
        }

        private void DeleteTaskStripMenu_Click(object sender, EventArgs e)
        {
            int selectedIndex = ListBoxTasks.SelectedIndex;
            if (selectedIndex != -1)
            {
                tasks.RemoveAt(selectedIndex);
                RefreshTaskList();
                SaveTasks();
            }
        }

        private void RefreshTaskList()
        {
            tasks.Sort();
            ListBoxTasks.Items.Clear();

            foreach (Task task in tasks)
            {
                ListBoxTasks.Items.Add($"Opis: {task.Description}, Data: {task.Date}, Priorytet: {task.Priority}");
            }
        }

        private void CreateNewTask()
        {
            Label descriptionLabel = new Label();
            TextBox descriptionTextBox = new TextBox();

            Label dateLabel = new Label();
            DateTimePicker datePicker = new DateTimePicker();

            Label priorityLabel = new Label();
            ComboBox priorityComboBox = new ComboBox();

            descriptionLabel.Text = "Opis";
            descriptionTextBox.Dock = DockStyle.Top;

            descriptionTextBox.Dock = DockStyle.Top;

            dateLabel.Text = "Data";
            datePicker.Dock = DockStyle.Top;
            datePicker.Format = DateTimePickerFormat.Custom;
            datePicker.CustomFormat = "dd.MM.yyyy HH:mm";

            priorityLabel.Text = "Priorytet";
            priorityComboBox.Items.AddRange(new object[] { "Wysoki", "Średni", "Niski" });
            priorityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            priorityComboBox.Dock = DockStyle.Top;

            Form form = new Form();
            form.Text = "Nowe zadanie";
            form.AutoSize = true;

            form.Controls.Add(descriptionLabel);
            form.Controls.Add(descriptionTextBox);

            form.Controls.Add(dateLabel);
            form.Controls.Add(datePicker);

            form.Controls.Add(priorityLabel);
            form.Controls.Add(priorityComboBox);

            descriptionLabel.Dock = DockStyle.Top;
            dateLabel.Dock = DockStyle.Top;
            priorityLabel.Dock = DockStyle.Top;

            Button confirmButton = new Button();
            confirmButton.Text = "Confirm";
            confirmButton.Click += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(descriptionTextBox.Text) || priorityComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Wprowadź opis i wybierz priorytet.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Task task = new Task
                {
                    Description = descriptionTextBox.Text,
                    Date = datePicker.Value,
                    Priority = priorityComboBox.SelectedItem.ToString()
                };
                tasks.Add(task);

                form.Close();
            };

            Button cancelButton = new Button();
            cancelButton.Text = "Cancel";
            cancelButton.Click += (sender, e) =>
            {
                form.Close();
            };

            confirmButton.Dock = DockStyle.Bottom;
            cancelButton.Dock = DockStyle.Bottom;

            form.Controls.Add(confirmButton);
            form.Controls.Add(cancelButton);

            form.ShowDialog();
        }

        private void EditTask(Task task)
        {
            Form editForm = new Form();
            editForm.Text = "Edytuj zadanie";
            editForm.AutoSize = true;

            TextBox descriptionTextBox = new TextBox();
            descriptionTextBox.Text = task.Description;

            DateTimePicker datePicker = new DateTimePicker();
            datePicker.Value = task.Date;
            datePicker.Format = DateTimePickerFormat.Custom;
            datePicker.CustomFormat = "dd.MM.yyyy HH:mm";

            ComboBox priorityComboBox = new ComboBox();
            priorityComboBox.Items.AddRange(new object[] { "Wysoki", "Średni", "Niski" });
            priorityComboBox.SelectedItem = task.Priority;
            priorityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            Button confirmButton = new Button();
            confirmButton.Text = "Confirm";
            confirmButton.Click += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(descriptionTextBox.Text))
                {
                    MessageBox.Show("Wprowadź opis.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                task.Description = descriptionTextBox.Text;
                task.Date = datePicker.Value;
                task.Priority = priorityComboBox.SelectedItem.ToString();

                RefreshTaskList();
                editForm.Close();
            };

            Button cancelButton = new Button();
            cancelButton.Text = "Cancel";
            cancelButton.Click += (sender, e) =>
            {
                editForm.Close();
            };

            editForm.Controls.Add(descriptionTextBox);
            editForm.Controls.Add(datePicker);
            editForm.Controls.Add(priorityComboBox);
            editForm.Controls.Add(confirmButton);
            editForm.Controls.Add(cancelButton);

            descriptionTextBox.Dock = DockStyle.Top;
            datePicker.Dock = DockStyle.Top;
            priorityComboBox.Dock = DockStyle.Top;
            confirmButton.Dock = DockStyle.Bottom;
            cancelButton.Dock = DockStyle.Bottom;

            editForm.ShowDialog();
        }

        private void LoadTasks()
        {
            try
            {
                if (File.Exists(Filename))
                {
                    string json = File.ReadAllText(Filename);
                    tasks = JsonConvert.DeserializeObject<List<Task>>(json);
                    RefreshTaskList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd w trakcie wczytywania zadań!: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveTasks()
        {
            try
            {
                string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
                File.WriteAllText(Filename, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd w zapisywaniu zadań!: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveTasks();
        }

        private void AboutStripMenu_Click(object sender, EventArgs e)
        {
            Form aboutDialog = new Form();
            aboutDialog.Text = "O aplikacji";
            aboutDialog.AutoSize = true;

            Label creatorLabel = new Label();
            creatorLabel.Text = "Twórca: Jakub Matusiak";
            creatorLabel.Dock = DockStyle.Top;

            Label versionLabel = new Label();
            versionLabel.Text = $"Wersja .NET: {Environment.Version}";
            versionLabel.Dock = DockStyle.Top;

            Button closeButton = new Button();
            closeButton.Text = "Zamknij";
            closeButton.Click += (_, __) => aboutDialog.Close();
            closeButton.Dock = DockStyle.Bottom;

            aboutDialog.Controls.Add(creatorLabel);
            aboutDialog.Controls.Add(versionLabel);
            aboutDialog.Controls.Add(closeButton);
            aboutDialog.ShowDialog();
        }

        private class Task : IComparable<Task>
        {
            public string Description { get; set; }
            public DateTime Date { get; set; }
            public string Priority { get; set; }

            public int CompareTo(Task other)
            {
                if (other == null) return 1;

                Dictionary<string, int> priorityOrder = new Dictionary<string, int>
                {
                     { "Wysoki", 0 },
                     { "Średni", 1 },
                     { "Niski", 2 }
                };

                return priorityOrder[Priority].CompareTo(priorityOrder[other.Priority]);
            }
        }
    }
}