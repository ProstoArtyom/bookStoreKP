   M S B A M L   `   `   `  ����G  CBookStore.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:BookStore.UI.Pages.AdminBookStore.UI.Pages.Admin  5      7 clr-namespace:BookStore.UI.PagesBookStore.UI.Pages  5      2    ,BookStore.UI.Pages.Admin.AdminOrdersListPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:BookStore.UI.Pages.Admin     5      /ps clr-namespace:BookStore.UI.Pages     5        N� Title$  AdminOrdersListPage��5	       � 	Resources 5
       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��$ 20(�6)   �� 5       � ��$ 10q�6'   �� 5       � ��$ Center=�62   �� 5       � ��$ Century)�6+   5      5      .��5      �� $
��Auto=�6   ��5   
   �� 5       �� Color$ White��6    �� Opacity$	 0.8Q�6,   .��5   
   � $��20q�6    � RowDefinitions 5      �� 5      $
��Auto �6    60   �� 5      6"   .+�5      �� $��0��6   $��Center=�6%   $��30(�5      $��20q�6&   Список заказов6B   &   System.Windows.Controls.DataGrid  5!      -   5          Name$ OrdersDataGrid��5!   $   $��1��6   	   AutoGenerateColumns$	 False��6<   $��20q�6X   
   
IsReadOnly$

 True��5"         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6)      RowBackground
 ���� 
������    HorizontalGridLinesBrush
 �iii�   VerticalGridLinesBrush
 �����$��16(�5%      
������ $��Disabled=�6>      RowHeaderStyle 5&      �� 5'      :  4System.Windows.Controls.Primitives.DataGridRowHeader"  6   .�5(      ��  � ��
 �iii�67   �� 5)       � ��
 �   �67   �� 5*       � ��$ Center=�6G   �� 5+       � ��$ Center=�6E   �� 5,       � ��$ 5q�64   5-         ColumnHeaderStyle 50      �� 51      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�52      ��  � ��
 �iii�67   �� 53       � ��
 �����67   �� 54       � ��$ Center=�6G   �� 55       � ��$ Center=�6E   �� 56       � ��$ 5q�64   �� 57       � ��$ Century Gothic)�67   58         	CellStyle 5;      �� 5<      *  $System.Windows.Controls.DataGridCell"  6   .�5=      ��  � ��$ 5q�64   �� 5>       � �� 5?      �� 5@   "    �� 
TargetType"  62   .R�5A   &   ��  �� Padding# z��6-   #��z��5B   -   #��z��5C   -   #��z��5D   -    J� SnapsToDevicePixels$
 True��5E   -   ._�5F   *   �� # z 6;   5G   '   5H   #   5J       �� Triggers 5K      P� 5L       P� Property �@ 
IsSelected P� Value$
 True��6I   . �5M   "   ��  � �� �#DCDCDC6?   5N      5P         Columns 5S      4  .System.Windows.Controls.DataGridTemplateColumn  5T      ,  &System.Windows.Controls.DataGridColumn   Header$ Номер заказа��6-      Width$
 Auto 6C      CellTemplate 5U      �� 5V      .R�5W   "   �� �� 5X   &   $�Заказ №��6*    �� 5Y   &   �6*   �� *Id+5Z   #   5[      5]        5^      $# Номер владельца��6-   $
 Auto 6F    5_      �� 5`      .R�5a   "   �� �� 5b   &   $"�Пользователь №��6*    �� 5c   &   �6*   �� *IdUser+5d   #   5e      5g      0  *System.Windows.Controls.DataGridTextColumn  5h      $ Дата создания��6)   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6@   �� *DateTimeCreated+  5i      $ Цена��6)    67   �� *Price+5k      5l      5m      5n      