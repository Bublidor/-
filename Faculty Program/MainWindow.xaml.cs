using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace Faculty
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new StudentViewModel();
        }

        private void ColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            if (headerClicked != null)
            {
                string header = headerClicked.Column.Header as string;
                if (DataContext is StudentViewModel viewModel)
                {
                    viewModel.Sort(header);
                }
            }
        }
    }

    public class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        private string _subject;
        public string Subject
        {
            get { return _subject; }
            set
            {
                _subject = value;
                OnPropertyChanged(nameof(Subject));
            }
        }

        private double? _grade;
        public double? Grade
        {
            get { return _grade; }
            set
            {
                _grade = value;
                OnPropertyChanged(nameof(Grade));
            }
        }

        private string _groupName;
        public string GroupName
        {
            get { return _groupName; }
            set
            {
                _groupName = value;
                OnPropertyChanged(nameof(GroupName));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class StudentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Student> Students { get; set; }

        public ICommand AddStudentCommand { get; }
        public ICommand DeleteStudentCommand { get; }
        public ICommand SearchStudentCommand { get; }

        private string _newFullName;
        public string NewFullName
        {
            get { return _newFullName; }
            set
            {
                _newFullName = value;
                OnPropertyChanged(nameof(NewFullName));
            }
        }

        private string _newSubject;
        public string NewSubject
        {
            get { return _newSubject; }
            set
            {
                _newSubject = value;
                OnPropertyChanged(nameof(NewSubject));
            }
        }

        private double? _newGrade;
        public double? NewGrade
        {
            get { return _newGrade; }
            set
            {
                _newGrade = value;
                OnPropertyChanged(nameof(NewGrade));
            }
        }

        private string _newGroupName;
        public string NewGroupName
        {
            get { return _newGroupName; }
            set
            {
                _newGroupName = value;
                OnPropertyChanged(nameof(NewGroupName));
            }
        }

        private string _searchLastName;
        public string SearchLastName
        {
            get { return _searchLastName; }
            set
            {
                _searchLastName = value;
                OnPropertyChanged(nameof(SearchLastName));
            }
        }

        private Student _selectedStudent;

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                if (_selectedStudent != value)
                {
                    _selectedStudent = value;
                    OnPropertyChanged(nameof(SelectedStudent));
                }
            }
        }

        public StudentViewModel()
        {
            Students = new ObservableCollection<Student>();
            AddStudentCommand = new RelayCommand(AddStudent);
            DeleteStudentCommand = new RelayCommand(DeleteStudent);
            SearchStudentCommand = new RelayCommand(SearchStudent);
            NewFullName = string.Empty;
            NewSubject = string.Empty;
            NewGrade = null;
            NewGroupName = string.Empty;
        }

        public void Sort(string sortBy)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(Students);
            if (dataView != null)
            {
                if (dataView.SortDescriptions.Count > 0 && dataView.SortDescriptions[0].PropertyName == sortBy)
                {
                    SortDescription currentSort = dataView.SortDescriptions[0];
                    ListSortDirection newDirection = (currentSort.Direction == ListSortDirection.Ascending) ?
                        ListSortDirection.Descending : ListSortDirection.Ascending;

                    dataView.SortDescriptions.Clear();
                    dataView.SortDescriptions.Add(new SortDescription(sortBy, newDirection));
                }
                else
                {
                    dataView.SortDescriptions.Clear();
                    dataView.SortDescriptions.Add(new SortDescription(sortBy, ListSortDirection.Ascending));
                }
            }
        }

        private void AddStudent(object parameter)
        {
            if (string.IsNullOrWhiteSpace(NewFullName))
            {
                MessageBox.Show("Please enter the student's full name.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(NewSubject))
            {
                MessageBox.Show("Please enter the subject.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (NewGrade == null)
            {
                MessageBox.Show("Please enter the grade.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(NewGroupName))
            {
                MessageBox.Show("Please enter the group name.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newStudent = new Student
            {
                FullName = NewFullName,
                Subject = NewSubject,
                Grade = NewGrade,
                GroupName = NewGroupName
            };

            Students.Add(newStudent);
            ClearInputFields();
        }

        private void DeleteStudent(object parameter)
        {
            if (SelectedStudent != null)
            {
                Students.Remove(SelectedStudent);
            }
        }

        private void SearchStudent(object parameter)
        {
            var student = Students.FirstOrDefault(s => s.FullName.IndexOf(SearchLastName, StringComparison.OrdinalIgnoreCase) >= 0);

            if (student != null)
            {
                MessageBox.Show($"Student found:\nFull Name: {student.FullName}\nGroup: {student.GroupName}\nSubject: {student.Subject}\nGrade: {student.Grade}", "Student Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Student not found.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ClearInputFields()
        {
            NewFullName = null;
            NewSubject = null;
            NewGrade = null;
            NewGroupName = null;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}

