   M S B A M L   `   `   `  ����J  FFaculty Program, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:FacultyFaculty  5   	       Faculty.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Faculty     5   	   ���#afb7c7  � Title$  Faculty Program��5	   	   $	��650��6!   $	��800��6.    � DataContext 5
         Faculty.StudentViewModel  5   
    � 	Resources 5       �� 
TargetType �� Property �� Value&   System.Windows.Media.TextOptions��%�  '��       '�� @    �� 5   
   " ��6   .�5      ��  � ��$ Arial)�6+   6;   �� 5       � ��$ 10 0 0 0q�6'   6:   �� 5       �@ TextRenderingMode$ 	ClearType=�6>   �� 5       �@ TextFormattingMode$ Ideal=�6?   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 18(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$ 0 0 0 10q�6'   6:   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5!   
   � $��10q�6    � ColumnDefinitions 5"      �� 5#      $��* �6#   �� 5$      $��* �6#   �� 5%      $��* �6#   �� 5&      $��* �6#    5(      �� 5)      $
��Auto �6    �� 5*      $
��Auto �6    �� 5+      $
��Auto �6    �� 5,      $
��Auto �6    �� 5-      $
��Auto �6    �� 5.      $��* �6    .+�51      �� $��4��6   $��Center=�6,   $��	0 20 0 20q�6I   ���#373c46$��36(�6q   Faculty Management6�   �� 53      $��
Full Name:��6   $��1��6*   $��0��67   �� 54      $��1��6X   $��1��6e   $��3��6u   ��6   �� *NewFullName+ �� UpdateSourceTrigger$ PropertyChanged=�6u   �� 56      $��Subject:��6   $��2��6(   $��0��65   �� 57      $��2��6W   $��1��6d   $��3��6t   ��6   �� *
NewSubject+$ PropertyChanged=�6t   �� 59      $��Grade:��6   $��3��6&   $��0��63   �� 5:      $��3��6U   $��1��6b   $��3��6r   ��6   �� *
NewGrade+$ PropertyChanged=�6r   �� 5<      $��Group Name:��6   $��4��6+   $��0��68   �� 5=      $��4��6Y   $��1��6f   $��3��6v   ��6   �� *NewGroupName+$ PropertyChanged=�6v   �� 5?      $��Add Student��6   $��5��6Q   $��0��6^   $��2��6n   $��10,38.6,182.4,-96.6q�6�   ��6+   �� *AddStudentCommand+6�   �� 5@      $��Delete Student��6   $��5��6W   $��1��6d   $��10.4,38.6,183.2,-96.6q�6t   $��2��6�   ��6.   �� *DeleteStudentCommand+6�   �� 5A      $��4��6[   $��1��6h   $��2��6x   $��192.4,26.8,0.2,10.4q�6�   $��2��6�   ��6   �� *SearchLastName+$ PropertyChanged=�6�   �� 5B      $��Search Student��6   $��5��6W   $��2��6d   $��2��6t   $��191.6,33.6,10,-96.6q�6�   ��6.   �� *SearchStudentCommand+6�   �� 5D      $��6��6   $��4��6$   $��10q�6�   $��Stretch=�6�   $��Stretch=�6�   ��68   �� *
Students+	 �� SelectedItem	 6Y   �� *SelectedStudent+
 �� View
 5E      �� 5F      .P�5G      �� $��	Full Name��6)    �� Width$	 200��6f    �� DisplayMemberBinding 6<   �� *
FullName+6f   �� 5H      $��Subject��6)   $	 200��6c    6:   �� *	Subject+6c   �� 5I      $��Grade��6)   $	 100��6_    68   �� *Grade+6_   �� 5J      $��
Group Name��6)   $	 200��6h    6=   �� *	GroupName+6h   5K      5M      5N      5O      5P      