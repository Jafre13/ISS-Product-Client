   M S B A M L   `   `   `  ���� E  AISS-Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ISS_Client
ISS_Client      ISS_Client.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:ISS_Client       � Title$  
MainWindow��$	��900��$
��1200�� � DataContext$  ��.����  �� Orientation$ 
Horizontal=�$
��Left=�$	��900��$	��Top=�$
��1200��.+��� $	��600��$	��900��.+��� $	��100��$��30��$��Center=� �� TextAlignment$ Center=�$��24(�	Subject�� -    ��Name$ subject_box��$	��450��$��50��$��Center=��� $	��100��$��30��$ Center=�$��24(�$��0,20,0,0q�	Message�� -   $ textBox��$	��450��$	��600��$��20q� �� TextWrapping$
 Wrap=� �� AcceptsReturn . �� -    ��Name$ 
sendButton��$��10q�.��Send�� $ Vertical=�.+��� $	��800��.+��� $��Center=�$��32(�States�� $ 
Horizontal=�$��Center=�.+��� -   $��20q�.��Work�� -   $��20q�.��Urgent�� -   $��20q�.��Spam�� -   $��20q�.��	Meeting�� -   $��20q�.��
Contract�� -	   $��20q�.��All&   System.Windows.Controls.DataGrid  -
     Name$
 grid��	   AutoGenerateColumns	 .  
   CanUserAddRows
 .  ���� *
myMessages+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   MaxWidth$	 100Q�   Header$ Subject��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	Subject+  $ Created�� �� *	Created+  $ 	Scheduled�� �� *relevance_time+  $ Category�� �� *
category+  $ Priority�� �� *
priority+4  .System.Windows.Controls.DataGridTemplateColumn  $ Re-Train��   CellTemplate �� .R��� $ re_train_button��-   .��Train�� .+��� -   $��Big Black Magic Box��