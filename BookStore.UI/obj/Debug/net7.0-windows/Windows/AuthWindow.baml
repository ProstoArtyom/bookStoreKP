   M S B A M L   `   `   `  ����G  CBookStore.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BookStore.UI.WindowsBookStore.UI.Windows  5   	   %    BookStore.UI.Windows.AuthWindow   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   1ws"clr-namespace:BookStore.UI.Windows     5   	     � Title$%  Окно авторизации��5   	   $	��480��6"   $	��700��6/    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�6   ��5
      �� 5   
    �� ImageSource$. (../Resourses/Images/brick-background.png��6    j� Stretch$
 None=�5      5      .��5      � $��15q�6    � ColumnDefinitions 5   
   �� 5      $	��200 �6   6-   �� 5      6!   .+�5   
   � $��0��6   ��5      �� 5       �� Color$ CornflowerBlue��6"    �� Opacity$	 0.8Q�69   6I   .+�5      � $��20q�6    � RowDefinitions 5      �� 5      6&   �� 5      $
��Auto �6$   64   �� 5      $
��Auto �6$   64   �� 5       6&   .+�5#      �� $��1��6   $��Center=�6%   $
��Bold"�6B   $��30(�6T   
�������$��2��5$   0   .��6D   	Welcome6M   �� 5%      $��2��6   $��Center=�6%   $��14(�6B   
�������$��2��5&   0   .��6D   Sign in to continue.6Z   5'      5(       � 5*   
   -   5        $��	AuthFrame��5*       $��1��6   	  � NavigationUIVisibility$	 Hidden=�61   
  � Source$.
 (../Pages/Authorization/UserAuthPage.xaml?�5+      5,      5-      