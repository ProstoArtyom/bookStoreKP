   M S B A M L   `   `   `  ����G  CBookStore.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:BookStore.UI.Pages.AdminBookStore.UI.Pages.Admin  5      7 clr-namespace:BookStore.UI.PagesBookStore.UI.Pages  5      4    .BookStore.UI.Pages.Admin.AdminAccountsListPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:BookStore.UI.Pages.Admin     5      /ps clr-namespace:BookStore.UI.Pages     5        N� Title$  AdminAccountsListPage��5	       � 	Resources 5
       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��$ 20(�6)   �� 5       � ��$ 10q�6'   �� 5       � ��$ Center=�62   �� 5       � ��$ Century)�6+   5      5      .��5      �� $
��Auto=�6   ��5   
   �� 5       �� Color$ White��6    �� Opacity$	 0.8Q�6,   .��5   
   � $��20q�6    � RowDefinitions 5      �� 5      $
��Auto �6    60   �� 5      6"   .+�5      �� $��0��6   $��Center=�6%   $��30(�5      $��20q�6&   ,*Список учётных записей5!      &   System.Windows.Controls.DataGrid  5#      -   5          Name$ AccountsDataGrid��5#   $   $��1��6   	   AutoGenerateColumns$	 False��6>   $��20q�6Z   
   
IsReadOnly$

 True��5%         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6)      RowBackground
 ���� 
������    HorizontalGridLinesBrush
 �iii�   VerticalGridLinesBrush
 �����$��16(�5(      
������ $��Disabled=�6>   ��5$      ��  �� Path$ Accounts� �� Mode$ OneWay=�   RowHeaderStyle 5)      �� 5*      :  4System.Windows.Controls.Primitives.DataGridRowHeader"  6   .�5+      ��  � ��
 �iii�67   �� 5,       � ��
 �   �67   �� 5-       � ��$ Center=�6G   �� 5.       � ��$ Center=�6E   �� 5/       � ��$ 5q�64   50         ColumnHeaderStyle 53      �� 54      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�55      ��  � ��
 �iii�67   �� 56       � ��
 �����67   �� 57       � ��$ Center=�6G   �� 58       � ��$ Center=�6E   �� 59       � ��$ 5q�64   �� 5:       � ��$ Century Gothic)�67   5;         	CellStyle 5>      �� 5?      *  $System.Windows.Controls.DataGridCell"  6   .�5@      ��  � ��$ 5q�64   �� 5A       � �� 5B      �� 5C   "    �� 
TargetType"  62   .R�5D   &   ��  �� Padding# z��6-   #��z��5E   -   #��z��5F   -   #��z��5G   -    J� SnapsToDevicePixels$
 True��5H   -   ._�5I   *   �� # z 6;   5J   '   5K   #   5M       �� Triggers 5N      P� 5O       P� Property �@ 
IsSelected P� Value$
 True��6I   . �5P   "   ��  � �� �#DCDCDC6?   5Q      5S         Columns 5V      0  *System.Windows.Controls.DataGridTextColumn  5W      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6)      Width$
 Auto 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *IdUser+6S     5X      $ 
Логин��6)    68   �� *Login+  5Y      $ Фамилия��6)    6:   �� *Name+  5Z      $ Имя��6)    66   �� *	Surname+  5[      $' !Электронная почта��6)    6D   �� *Email+5]      5^      5_      5`      