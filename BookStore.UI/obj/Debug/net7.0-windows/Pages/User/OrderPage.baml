   M S B A M L   `   `   `  ����G  CBookStore.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:BookStore.UI.Pages.UserBookStore.UI.Pages.User  5      7 clr-namespace:BookStore.UI.PagesBookStore.UI.Pages  5      '    !BookStore.UI.Pages.User.OrderPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:BookStore.UI.Pages.User     5      /ps clr-namespace:BookStore.UI.Pages     5        N� Title$  	OrderPage��5	       � 	Resources 5
       �� 
TargetType �� Property �� Value �� 	Resources��%'  '��       '�� �    �� 5   
   " ��6   .�5      ��  � ��$ 5q�6(   �� 5       � ��$ 10q�6'   �� 5       � ��$ 20(�6)   �� 5       � ��
 ��d�6+   �� 5       � ��
 �����6+   �� 5       � ��$ 0q�60   �� 5       � ��$ Ink Free)�6+    5      ���� 5      '��       " ��6   .�5      ��  �@��CornerRadius$ 10��65   5      5      5      �� 5   
   " ��6   .�5      ��  � ��$ Century)�6+   �� 5       � ��$ 20(�6)   5      5      .��5!      �� $
��Auto=�6   ��5"   
   �� 5#       �� Color$ White��6    �� Opacity$	 0.8Q�6,   .��5&   
   � $��30q�6    � RowDefinitions 5'      �� 5(      $
��Auto �6    60   �� 5)      $
��Auto �6    60   �� 5*      $
��Auto �6    60   �� 5+      6"   .+�5.      �� -   5        $��0��5.      $
��Left=�6"   $	��150��5/      .��67   
НАЗАД6>   �� 51      $��0��6   	 �� Orientation$	 
Horizontal=�6&   $��Right=�6?   .+�52      �� -   5        $	��200��52      .��6=   ЭКСПОРТ В .txt6M   �� 53      -   5        $	��150��53      .��6<   ПЕЧАТЬ6D   54      � 56      -   5        
 �Name$
 	OrderGrid��56   ,   $��1��6   $��10q�6     57      �� 58      $
��Auto �6$   64   �� 59      6&    � ColumnDefinitions 5<      �� 5=      $
��Auto �6'   66   �� 5>      6)   .+�5A      �� -   5         ��Name$ OrderInfoPanel��5A   -   $��1��6   .+�5B      �� $	 
Horizontal=�6!   .+�5C      �� $��Заказ № ��6$   $��22(�64   �� 5D      $��22(�68   ��6$   �� *Id+68   5E      �� 5G      $	 
Horizontal=�6!   .+�5H      �� $��Статус: ��6$   $��22(�64   �� 5I      $��22(�6<   ��6$   �� *Status+6<   5J      �� 5L      $	 
Horizontal=�6!   .+�5M      �� $!��Способ оплаты: ��6$   $��22(�6;   �� 5N      $��22(�6=   ��6$   �� *	Payment+6=   5O      �� 5Q      $	 
Horizontal=�6!   $��0, 25, 0, 0q�6:   .+�5R      �� $!��Дата создания: ��6$   $��22(�6;   �� 5S      $��22(�6E   ��6$   �� *DateTimeCreated+6E   5T      �� 5V      $	 
Horizontal=�6!   .+�5W      �� $��
Цена: ��6$   $��22(�62   �� 5X      $��22(�6;   ��6$   �� *Price+6;   �� 5Y      $
��р. ��6$   $��22(�6/   5Z      5[      &   System.Windows.Controls.DataGrid  5]      -   5          Name$ BooksGridView��5_      $��1��5]      $��2��6(   $��0, 10, 0, 10q�5^      $��Disabled=�61      AutoGenerateColumns$ False��5_   2      
IsReadOnly$
 True��5a         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6-      RowBackground
 ���� 
������    HorizontalGridLinesBrush
 �iii�   VerticalGridLinesBrush
 �����$��16(�5d      
������ ��5a   =   �� *Books+   RowHeaderStyle 5e      �� 5f      :  4System.Windows.Controls.Primitives.DataGridRowHeader"  6    .�5g      ��  � ��
 �iii�6;   �� 5h       � ��
 �   �6;   �� 5i       � ��$ Center=�6K   �� 5j       � ��$ Center=�6I   �� 5k       � ��$ 5q�68   5l         ColumnHeaderStyle 5o      �� 5p      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6    .�5q      ��  � ��
 �iii�6;   �� 5r       � ��
 �����6;   �� 5s       � ��$ Center=�6K   �� 5t       � ��$ Center=�6I   �� 5u       � ��$ 5q�68   �� 5v       � ��$ Century Gothic)�6;   5w         	CellStyle 5z      �� 5{      *  $System.Windows.Controls.DataGridCell"  6    .�5|      ��  � ��$ 5q�68   �� 5}       � �� 5~   "   �� 5   &    �� 
TargetType"  66   .R�5�   *   ��  �� Padding# z��61   #��z��5�   1   #��z��5�   1   #��z��5�   1    J� SnapsToDevicePixels$
 True��5�   1   ._�5�   .   �� # z 5�   1   5�   +   5�   '   5�       �� Triggers 5�      P� 5�   "    P� Property �@ 
IsSelected P� Value$
 True��6M   . �5�   &   ��  � �� �#DCDCDC6C   5�   #   5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Title+  5�      $ 
Автор��6-    6<   �� *Author+  5�      $ Категория��6-    6@   �� *
Category+  5�      $ Цена��6-    6;   �� *Price+5�      5�      5�      5�      5�      