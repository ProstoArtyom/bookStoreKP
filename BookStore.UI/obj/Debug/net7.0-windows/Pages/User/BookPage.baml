   M S B A M L   `   `   `  ����G  CBookStore.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:BookStore.UI.Pages.UserBookStore.UI.Pages.User  5      7 clr-namespace:BookStore.UI.PagesBookStore.UI.Pages  5      G(clr-namespace:BookStore.UI.HelperClassesBookStore.UI.HelperClasses  5      =#clr-namespace:BookStore.UI.ControlsBookStore.UI.Controls  5	      &     BookStore.UI.Pages.User.BookPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:BookStore.UI.Pages.User     5      /ps clr-namespace:BookStore.UI.Pages     5      ?
Converters(clr-namespace:BookStore.UI.HelperClasses     5      3con#clr-namespace:BookStore.UI.Controls     5	        N� Title$  BookPage��5       � 	Resources 5       �� 
TargetType �� Property �� Value �� 	Resources@   :BookStore.UI.HelperClasses.ByteArrayToImageSourceConverter   ByteArrayToImageConverter��%D  '��       '�� �    &	      �� 5   
   " ��6   .�5      ��  � ��$ 5q�6(   �� 5       � ��$ 10q�6'   �� 5       � ��$ 20(�6)   �� 5       � ��
 ��d�6+   �� 5       � ��
 �����6+   �� 5       � ��$ 0q�60   �� 5       � ��$ Ink Free)�6+    5      ���� 5      '��       " ��6   .�5      ��  �@��CornerRadius$ 10��65   5      5      5      �� 5   
   " ��6   .�5      ��  � ��$ Century)�6+   �� 5       � ��$ 20(�6)   5         5"   
   65   5#      .��5%      �� $
��Auto=�6   ��5&   
   �� 5'       �� Color$ White��6    �� Opacity$	 0.8Q�6,   .��5*   
   � $��20q�6    � RowDefinitions 5+      �� 5,      $
��Auto �6    60   �� 5-      $
��Auto �6    60   �� 5.      6"   �� 5/      $
��Auto �6    60   .+�52      � $��0��6   $��10, 10, 0, 0q�6    	 � ColumnDefinitions	 53      �� 54      $
��Auto �6'   66   �� 55      6)   .+�58      �� $	��500��59      $	��300��6$   $��10q�64   ��58      �� *Image+
 �� 	Converter#
 [  59   B   �� 5;      $��1��6   $��30q�6-   .+�5<      �� $
��Bold"�67   $��30(�6I   ��6    �� *Title+6I   �� 5>       �� Orientation$ 
Horizontal=�6!   .+�5?      �� ��6$   �� *Author+5@      �� 5B      $ 
Horizontal=�6!   $��0, 25, 0, 0q�6:   .+�5C      �� ��6$   �� *
Category+5D      �� 5F      $ 
Horizontal=�6!   .+�5G      �� $��ISBN: ��6$   $��22(�62   $
��Bold"�6@   �� 5H      $��22(�6:   ��6$   �� *Isbn+6:   5I      �� 5K      $ 
Horizontal=�6!   $��0, 25, 0, 0q�6:   .+�5L      �� $��28(�6;   $
��Bold"�6I   ��6$   �� *Price+6I   �� 5M      $
�� р.��6$   $��28(�6/   $
��Bold"�6=   5N      � 5P      -   5         �Name$ AddToCartGrid��5P       5Q      �� 5R      $
��Auto �6,   6<   �� 5S      $
��Auto �6,   6<   	 5V      �� 5W      $
��Auto �6/   6>   �� 5X      $
��Auto �6/   6>   .+�5[      �� $��0��6%   $��0��62   $ 
Horizontal=�5\   %   $��0, 25, 0, 0q�6>   .+�5]      �� $��Осталось: ��6(   $��22(�6:   �� 5^      $��22(�6?   ��6(   �� *Count+6?   5_      1   +BookStore.UI.Controls.NumericTextBoxControl  5a      -   5          Name$ numericTextBoxControl��5a   Q   $��1��64   $��0��6A   $��Center=�5b      $
��Left=�68   �� 5c      -   5        $��1��5c   !   $��1��6.   $��30, 5, 30, 5q�6>   .��5d   ?   В корзину6J   5e      �� 5g      -   5         ��Name$ 	StatusTbl��5g       $��0, 10, 0, 0q�63   $y�	Collapsed=�5h       Нет в наличии!6G   5i      5j      � 5l      $��1��6   $��30, 0, 30, 10q�6     5m      �� 5n      $
��Auto �6$   64   �� 5o      6&   .+�5r      �� $��0��6   $��ОПИСАНИЕ:��6)   $
��Bold"�6:   �� 5s      $��1��6   $
��Wrap=�6F   ��6)   �� *Description+6F   5t      �� 5v      -   5        $��3��5v      $��Right=�6"   $��20q�5w      $��30, 10, 30, 10q�6!   .��6:   
Назад6A   5x      5y      5z      