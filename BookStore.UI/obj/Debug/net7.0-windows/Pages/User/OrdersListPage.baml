   M S B A M L   `   `   `  ����G  CBookStore.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:BookStore.UI.PagesBookStore.UI.Pages  5      A%clr-namespace:BookStore.UI.Pages.UserBookStore.UI.Pages.User  5      ,    &BookStore.UI.Pages.User.OrdersListPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /ps clr-namespace:BookStore.UI.Pages     5      7local%clr-namespace:BookStore.UI.Pages.User     5        N� Title$  
OrdersPage��5	       � 	Resources 5
       �� 
TargetType �� Property �� Value �� ScaleX �� ScaleY �� 	Resources��%�  '	�       '�� �     '�� %    '�� o    '�� +    '�� �    '�� �    �� 5   
   " 	�6   .�5      ��  �@�LayoutTransform 5      �� 5      $	 1.5Q�6%   $	 1.5Q�62   5      �� 5       � ��$ Ink Free)�6+   5      �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   �� 5       � ��$ Center=�62   5      �� 5   
   " ��6   .�5      ��  � ��
 ���� 6,   5      �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   �� 5       � ��$ 5q�6'   �� 5        � ��$ Center=�62   �� 5!       � ��$ Century)�6+   5"      �� 5$   
   " ��6   .�5%      ��  � ��$ 20(�6)   �� 5&       � ��$ 10q�6'   �� 5'       � ��$ Center=�62   �� 5(       � ��$ Century)�6+   5)      �� 5+   
   " ��6   .�5,      ��  � ��$ 18(�6)   �� 5-       � ��$ 5q�6'   �� 5.       � ��$ Center=�62   �� 5/       � ��$ Century)�6+   50      �� 52   
   " ��6   .�53      ��  � ��$ 20(�6)   �� 54       � ��$ 5q�6'   �� 55       � ��$ Center=�62   �� 56       � ��$ Century)�6+   �� 57       � ��
 �����6+   �� 58       � ��
 ��d�6+   �� 59       � ��$ 5q�6(    5;      ���� 5<      '��       " ��6   .�5=      ��  �@��CornerRadius$ 5��65   5>      5?      5@      5A      .��5C      �� $
��Auto=�6   ��5D   
   �� 5E       �� Color$ White��6   	 �� Opacity$		 0.8Q�6,   .��5H   
   � $��20q�6   
 � RowDefinitions
 5I      �� 5J      $
��Auto �6    60   �� 5K      6"   .+�5N      �� $��0��6   $��Center=�6%   $��30(�5O      $��20q�6&   История заказов5Q      &   System.Windows.Controls.DataGrid  5S      -   5          Name$ OrderDataGrid��5T      $��1��5S      $��20q�6$      AutoGenerateColumns$ False��5T   .      
IsReadOnly$
 True��5U         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6)      RowBackground
 ���� 
������    HorizontalGridLinesBrush
 �iii�   VerticalGridLinesBrush
 �����$��16(�5X      
������    RowHeaderStyle 5Y      �� 5Z      :  4System.Windows.Controls.Primitives.DataGridRowHeader"  6   .�5[      ��  � ��
 �iii�67   �� 5\       � ��
 �   �67   �� 5]       � ��$ Center=�6G   �� 5^       � ��$ Center=�6E   �� 5_       � ��$ 5q�64   5`         ColumnHeaderStyle 5c      �� 5d      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5e      ��  � ��
 �iii�67   �� 5f       � ��
 �����67   �� 5g       � ��$ Center=�6G   �� 5h       � ��$ Center=�6E   �� 5i       � ��$ 5q�64   �� 5j       � ��$ Century Gothic)�67   5k         	CellStyle 5n      �� 5o      *  $System.Windows.Controls.DataGridCell"  6   .�5p      ��  � ��$ 5q�64   �� 5q       � �� 5r      �� 5s   "    �� 
TargetType"  62   .R�5t   &   ��  �� Padding# z��6-   #��z��5u   -   #��z��5v   -   #��z��5w   -    J� SnapsToDevicePixels$
 True��5x   -   ._�5y   *   �� # z 6;   5z   '   5{   #   5}       �� Triggers 5~      P� 5       P� Property �@ 
IsSelected P� Value$
 True��6I   . �5�   "   ��  � �� �#DCDCDC6?   5�      5�         Columns 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Номер заказа��6-      CellTemplate 5�      �� 5�      .R�5�   "   �� �� 5�   &   $�Заказ №��6*    �� 5�   &   �6*   �� *Id+5�   #   5�      5�      0  *System.Windows.Controls.DataGridTextColumn  5�      $ Статус��6)   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 69   �� *Status+  5�      $ Способ оплаты��6)    6@   �� *	Payment+  5�      $ Дата создания��6)    6@   �� *DateTimeCreated+  5�      $ Цена��6)    67   �� *Price+5�      �� 5�      -   5         ��Name$ OrdersStatusLbl��5�   %   $��1��6   $y�	Collapsed=�6>   $	��Top=�5�      +)История заказов пуста!6H   5�      5�      5�      