   M S B A M L   `   `   `  ����G  CBookStore.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:BookStore.UI.PagesBookStore.UI.Pages  5      A%clr-namespace:BookStore.UI.Pages.UserBookStore.UI.Pages.User  5      *    $BookStore.UI.Pages.User.UserMainPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /ps clr-namespace:BookStore.UI.Pages     5      7local%clr-namespace:BookStore.UI.Pages.User     5        N� Title$  UserMainPage��5	      .��5
      � $��15q�6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   6.   �� 5      6!   .+�5   
   � $��0��6   ��5      �� 5       �� Color$ CornflowerBlue��6"    �� Opacity$	 0.8Q�69   6I    � RowDefinitions 5      �� 5      $
��Auto �6    60   �� 5      6"   �� 5      $
��Auto �6    60   .+�5      �� $��20q�6    � 	Resources 5       �� 
TargetType �� Property �� Value��%s  '��       '�� �     '�� p    �� 5      " ��6   .�5      ��  � ��
 ���� 67   �� 5       � ��
 ���� 68   �� 5        � ��$ 5q�63   �� 5!       � ��$ 80��62   5"      �� 5$      " ��6   .�5%      ��  � ��$ 40��63   �� 5&       � ��$ 5q�63   �� 5'       � ��$ Center=�6>   �� 5(       � ��$
 Auto��62   5)      �� 5+      " ��6   .�5,      ��  � ��$ Center=�6@   �� 5-       � ��
 �����67   �� 5.       � ��$
 Bold"�67   �� 5/       � ��$ Century)�67   �� 50       � ��$ 16(�65   51      52      .+�54      �� $��Center=�6   $��50��65   $%��../../Resourses/Icons/books.png��6A   �� 55      $��Center=�6   $��Century)�69   
�������$
��Bold"�56   4   $��30(�6F   БелКнига6^   �� 57      $��Center=�6   $��14(�65   
�������.��58   0   $"Рай книжного червя6D   �� 59      
�������66   �� 5;      -   5        .��5<      �� .+�5=      �� $$��../../Resourses/Icons/home.png��6    �� 5>      Home6*   5?      5@      �� 5B      -   5        .��5C      �� .+�5D      �� $$��../../Resourses/Icons/cart.png��6    �� 5E      Cart6*   5F      5G      �� 5I      -   5        .��5J      �� .+�5K      �� $&�� ../../Resourses/Icons/orders.png��6    �� 5L      Orders6,   5M      5N      �� 5P      -   5        .��5Q      �� .+�5R      �� $'��!../../Resourses/Icons/profile.png��6    �� 5S      	Account6-   5T      5U      5V      �� 5X      -   5        $��2��5X      $��15q�6"   $��16(�6.   $��Logout��6<   
���**��	 � ToolTip	 5Z      _� 5[      .��6   -+Выход из учётной записи67   5]      5^       � 5`   
   -   5        $��
BooksFrame��5`       $��1��6   
  � NavigationUIVisibility$
 Hidden=�62   5a      5b      