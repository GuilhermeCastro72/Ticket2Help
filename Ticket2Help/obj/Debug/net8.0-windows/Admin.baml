   M S B A M L   `   `   `  ����  Ticket2Help    Ticket2Help.Admin   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$   Admin - Gestão de Tickets��5   	   $	��600��6+   $	��900��68    � WindowStartupLocation$ CenterScreen=�6D   .��5      � $��15q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ listView��5      $��0��6%   $��0,0,0,10q�62   $��15(�6D    �� SelectionMode$ Single=�6R    �� View 5      �� 5      .P�5      �� $��ID��6%    �� Width$ 50��61    �� DisplayMemberBinding 6<   �� *Id+�� 5      $
��Tipo��6%   $	 120��63    6?   �� *Tipo+�� 5      $��Tarefa��6%   $	 150��65    6A   �� *
Informacao+�� 5      $��Descrição��6%   $	 300��68    6D   �� *	Descricao+�� 5      $��Colaborador��6%   $	 150��6:    6F   �� *Nome+�� 5      $��Status��6%   $	 100��65    6A   �� *StatusTicket+5      5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5      �� -   5        	 ��Name$	 btnReply��5      $��Responder Ticket��6'   $	��140��6B   $��35��6N   $	��5,0q�6Z   ���#2196F3
�������$��14(�5   =   6K   �� 5      -   5        $	 
btnDetails��5      $��Detalhes��6)   $	��100��6<   $��35��6H   $	��5,0q�6T   ���#FF9800
�������$��14(�5   =   6K   �� 5      -   5        $	 btnCheckUsers��5      $��Ver Utilizadores��6,   $	��130��6G   $��35��6S   $	��5,0q�6_   ���#9C27B0
�������$��14(�5    =   6K   �� 5!      -   5        $	 btnDashboard��5!      $��	Dashboard��6+   $	��110��6?   $��35��6K   $	��5,0q�6W   ���#4CAF50
�������$��14(�5"   =   6K   �� 5#      -   5        $	 btnSair��5#      $
��Sair��6&   $��80��65   $��35��6@   $	��5,0q�6L   ���#F44336
�������$��14(�5$   =   6K   5%      5&      5'      