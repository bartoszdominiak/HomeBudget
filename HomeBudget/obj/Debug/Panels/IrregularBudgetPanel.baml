   M S B A M L   `   `   `  ����E  AHomeBudget, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HomeBudget.PanelsHomeBudget.Panels  5      ,    &HomeBudget.Panels.IrregularBudgetPanel   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:HomeBudget.Panels     5        N� Title$  
LoginPanel��5	       N� 
Background
 ����� N� 
FontFamily$ Source Sans Pro)�5
      .��5      � ���	#FFF6F6F6$
��Left=�6"   $	��800��6=   .+�5   
   �� -   5         ��Name$ InterfaceButton��5      $��=��6*   $
��Left=�66   $	��Top=�6Q   $	��60 ��6i   $��60��6u   $��48(�6�   $
��Bold"�6�    � Cursor$  ��6�   ���	#FF0099D5���	#FFEAEAEA$��Source Sans Pro Light)�6�    � 5   
   -   5          �Name$ InterfaceFrame��5      $�� ��6(   $
��Left=�63   $	��600��6N   $	��Top=�6[   $	��160��6s   $y�Hidden=�6   6�   �� 5   
   -   5        $ 
MenuButton��5      $
��Menu��6%   $
��Left=�64   $	��Top=�6O   $	��158��6g   $��63��6s   $y�Hidden=�6   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -   5        $ ExpensesButton��5      $��Nowy wydatek��6)   $
��Left=�6@   $	��Top=�6[   $	��158��6s   $��63��6   $y�Hidden=�6�   $��0,63,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -   5        $ AllExpensesButton��5      $��Historia wydatków��6,   $
��Left=�6H   $	��Top=�6c   $	��158��6{   $��63��6�   $y�Hidden=�6�   $��	0,126,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -   5        $ MonthPlansButton��5      $��Zaplanuj budżet��6+   $
��Left=�6E   $	��Top=�6`   $	��158��6x   $��63��6�   $y�Hidden=�6�   $��	0,189,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -   5        $ HistoryMonthPlansButton��5      $"��Historia realizacji budżetu��62   $
��Left=�6X   $	��Top=�6s   $	��158��6�   $��62��6�   $y�Hidden=�6�   $��	0,252,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6  �� 5   
   -   5        $ CategoriesButton��5      $��Moje kategorie wydatków��6+   $
��Left=�6M   $	��Top=�6h   $	��158��6�   $��63��6�   $y�Hidden=�6�   $��	0,376,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -	   5        $ IrregularBudgetButton��5      $��Moje wydatki nieregularne��60   $
��Left=�6T   $	��Top=�6o   $	��158��6�   $��62��6�   $y�Hidden=�6�   $��	0,314,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6  �� 5   
   -
   5        $ SettingsButton��5      $��Ustawienia użytkownika��6)   $
��Left=�6J   $	��Top=�6e   $	��158��6}   $��63��6�   $y�Hidden=�6�   $��	0,439,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -   5        $ LogOutButton��5      $��Wyloguj się��6'   $
��Left=�6=   $	��Top=�6X   $	��158��6p   $��61��6|   $y�Hidden=�6�   $��	0,502,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -   5         ��Name$ 	MainLabel��5      $��Moje wydatki nieregularne��6#   $��Center=�6G   $��165,10,61,0q�6d   $	��Top=�6y   $	��574��6�   $��70��6�   $��48(�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ IrregularExpensesGrid��5      $
��Left=�62   $��
180,78,0,0q�6M   $	��Top=�6a   $	��198��6y   $	��538��6�   ���	#FF0099D5
�������   RowBackground �	#FFE6F2FF	   AlternatingRowBackground	 �	#FF9FCADB
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Nazwa��6%      MinWidth$	 300Q�6R      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6a      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   ��  �� Path$
 Name�6n     5      $ Kwota roczna��6%   $	 100Q�6[   $
 Auto 6j    .  6;   �� $ Amount�6w     5      $ Recid��6%   $	 110Q�6U   $
 Auto 6d    .    
Visibility$ Hidden=�6�    64   �� $ __recid�6�   4  .System.Windows.Controls.DataGridTemplateColumn  5          CellTemplate 5!      �� 5"      .R�5#      �� -   5        $��60��5#   '   
 � Tag$	 aaa��65   ���	#FFFFCA50
���   �$��Source Sans Pro)�6   .��6�   	Modyfikuj6�   5$      5&        5'       5(      �� 5)      .R�5*      �� -   5        $	 aaa��5*   &   $��60��61   ���	#FFFFCA50
���   �$��Source Sans Pro)�6   .��6�   Usuń6�   5+      5-      5/      �� 50   
   -   5        $ 	InfoLabel��50      $.��(Dodawanie nowego wydatku nieregularnego:��6#   $
��Left=�6V   $��180,297,0,0q�6q   $	��Top=�6�    J� RenderTransformOrigin$ -4.86,-0.543&�6�   $	��385��6�   $��18(�6�   $
��Bold"�6�   �� 51   
   -   5        $ 
Info2Label��51      $��Nazwa wydatku: ��6$   $
��Left=�6>   $��180,339,0,0q�6Y   $	��Top=�6n   $ -4.86,-0.543&�6�   $	��110��6�   �� 52   
   -   5        $ 
Info3Label��52      $��Kwota roczna:��6$   $
��Left=�6<   $��180,373,0,0q�6W   $	��Top=�6l   $ -4.86,-0.543&�6�   $	��110��6�   �� 53   
   -   5         ��Name$ NameBox��53      $��Center=�6#   $��26��6@   $��290,339,251,0q�6L    �� TextWrapping$ NoWrap=�6c   $�� ��6y   $	��Top=�6�   $	��259��6�   $��18(�6�    �� MaxLines$ 1��6�   ���	#FFE6F2FF���	#FF0099D5$��Cambria)�6�   
���   � �� SelectionBrush �	#FF0099D56  �� 54   
   -   5        $ 	AmountBox��54      $��Center=�6%   $��26��6B   $��290,373,251,0q�6N   $ NoWrap=�6e   $�� ��6{   $	��Top=�6�   $	��259��6�   $��18(�6�   $ 1��6�   ���	#FFE6F2FF���	#FF0099D5$��Cambria)�6�   
���   � �	#FF0099D564  �� 56   
   -   5        $ 	AddButton��56      $%��Dodaj nowy wydatek nieregularny��6%   $
��Left=�6O   $��400,420,0,0q�6j   $	��Top=�6   $	��318��6�   $��36��6�   ���	#FF73797F$��20(�6�   $��Cambria)�6�   ���	#FFEAEAEA���	#FF0099D56  �� 57   
   -   5        $ ModifyButton��57      $$��Modyfikuj wydatek nieregularny��6(   $
��Left=�6Q   $��400,420,0,0q�6l   $	��Top=�6�   $	��318��6�   $��36��6�   ���	#FF73797F$��20(�6�   $��Cambria)�6�   ���	#FFEAEAEA���	#FF0099D5$y�Hidden=�6  6/  �� 58   
   -   5        $ 
BackButton��58      $��Powrót do dodawania��6&   $
��Left=�6D   $��180,420,0,0q�6_   $	��Top=�6t   $	��203��6�   $��36��6�   ���	#FF73797F$��20(�6�   $��Cambria)�6�   ���	#FFEAEAEA���	#FF0099D5$y�Hidden=�6  $ -0.222,-2.389&�6#  6I  5;      5<      