   M S B A M L   `   `   `  ����K  GStudentManageApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:StudentManageAppStudentManageApp  5   	   !    StudentManageApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:StudentManageApp     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ txtName��5
      $
��Left=�6#   $��	83,10,0,0q�6>   $�� ��6Q    �� TextWrapping$
 Wrap=�6Y   $	��Top=�6m   $	��120��6�   �� 5   
   $
��Name��6   $
��Left=�6   $��27,6,0,0q�6:   $	��Top=�6L   �� 5   
   $��Email��6   $
��Left=�6    $��	220,6,0,0q�6;   $	��Top=�6N   �� 5   
   -   5        $ txtEmail��5      $
��Left=�6$   $��
280,10,0,0q�6?   $�� ��6S   $
 Wrap=�6[   $	��Top=�6o   $	��120��6�   �� 5   
   $��Phone��6   $
��Left=�6    $��	419,6,0,0q�6;   $	��Top=�6N   �� 5   
   -   5        $ txtPhone��5      $
��Left=�6$   $��
468,10,0,0q�6?   $�� ��6S   $
 Wrap=�6[   $	��Top=�6o   $	��120��6�   �� 5   
   -   5         ��Name$ 	btnInsert��5      $��Insert��6$   $
��Left=�65   $��
322,37,0,0q�6P   $	��Top=�6d   $	��105��6|   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgStudents��5      $��27,84,373,83q�6'   �� 5   
   $��DeptNo��6   $
��Left=�6!   $��	607,6,0,0q�6<   $	��Top=�6O   �� 5   
   -   5        $ 	txtDeptNo��5      $
��Left=�6%   $��
664,10,0,0q�6@   $�� ��6T   $
 Wrap=�6\   $	��Top=�6p   $	��120��6�   �� 5   
   -   5        $ 
btnShowStu��5      $��Show Students��6%   $
��Left=�6=   $��
468,84,0,0q�6X   $	��Top=�6l   $	��165��6�   $��31��6�   6�   �� 5   
   -   5        $ btnUpdateStu��5      $��Update Students��6'   $
��Left=�6A   $��468,148,0,0q�6\   $	��Top=�6q   $	��165��6�   $��34��6�   6�   �� 5   
   -	   5        $ 	txtFilter��5      $
��Left=�6%   $��565,218,0,0q�6@   $�� ��6U   $
 Wrap=�6]   $	��Top=�6q   $��68��6�   $��35��6�   �� 5   
   -
   5        $ 	btnFilter��5      $��Filter��6$   $
��Left=�65   $��468,218,0,0q�6P   $	��Top=�6e   $��35��6}   $��82��6�   6�   5      5      