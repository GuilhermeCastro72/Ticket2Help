   M S B A M L   `   `   `  ����  Ticket2Help    Ticket2Help.Users_List   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Lista de Utilizadores��5   	   $	��500��6'   $	��850��64   ���#f0f4f8 � WindowStartupLocation$ CenterScreen=�5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5	      $��* �6   �� 5
      $
��Auto �6   .+�5   
   �� -   5         ��Name$ listView��5      $��16(�6%   $��0��63   $��0 0 0 20q�6@   ���#d1dce5$��1q�6h    �� View 5      �� 5      .P�5      �� $��ID��6%    �� Width$ 50��61    �� DisplayMemberBinding 6<   �� *Id+�� 5      $
��Nome��6%   $	 150��63    6?   �� *Nome+�� 5      $��Username��6%   $	 150��67    6C   �� *
Username+�� 5      $��Password��6%   $	 150��67    6C   �� *
Password+�� 5      $��Admin��6%   $	 100��64    6@   �� *Admin+5      5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��0 10 0 0q�6X   .+�5      �� -   5         ��Name$ 
btnAddUser��5      $��	Adicionar��6)   $	��150��6=   $��35��6I   $��16(�6U   ���#2b6cb0
����������#2b6cb0	 � Cursor$
	 Hand��5   S   $��5q�5      �� 5       -   5        $ btnEditUser��5       $��Editar��6*   $	��150��6;   $��35��6G   $��16(�6S   ���#2b6cb0
����������#2b6cb0$
	 Hand��5!   S   $��5q�5"      �� 5$      -   5        $ 
btnDelUser��5$      $��Eliminar��6)   $	��150��6<   $��35��6H   $��16(�6T   ���#e53e3e
����������#e53e3e$
	 Hand��5%   S   $��5q�5&      �� 5(      -   5        $ btnExit��5(      $
��Sair��6&   $	��150��65   $��35��6A   $��16(�6M   ���#4a5568
����������#4a5568$
	 Hand��5)   S   $��5q�5*      5+      5,      5-      