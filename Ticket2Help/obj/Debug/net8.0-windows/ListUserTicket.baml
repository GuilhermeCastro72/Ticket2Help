   M S B A M L   `   `   `  ����  Ticket2Help"    Ticket2Help.List_User_Ticket   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Tickets do Utilizador��5   	   $	��450��6'   $	��800��64    � WindowStartupLocation$ CenterScreen=�6@   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ listView��5      $��0��6%   $��0,0,0,10q�62   $��16(�6D    �� SelectionMode$ Single=�6R    �� View 5      �� 5      .P�5      �� $��ID��6%    �� Width$ 80��6U    �� DisplayMemberBinding 61   �� *Id+6U   �� 5      $
��Tipo��6%   $	 150��6Y    63   �� *Tipo+6Y   �� 5      $��Descrição��6%   $	 400��6a    68   �� *	Assunto+6a   �� 5      $
��Data��6%   $	 130��6`    63   �� *DataCriacao+6`   5      5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5      �� -   5        	 ��Name$	 
btnDetails��5      $��Detalhes��6)   $	��120��6<   $��35��6H   $��0,0,20,0q�6T   $��16(�6f   ���#2b6cb0
�������5   *   �� 5      -   5        $	 btnExit��5      $
��Sair��6&   $	��120��65   $��35��6A   $��16(�6M   ���#F44336
�������5   *   5      5      5      