   M S B A M L   `   `   `  ����E  AHomeBudget, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HomeBudget.PanelsHomeBudget.Panels  5      '    !HomeBudget.Panels.MonthPlansPanel   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:HomeBudget.Panels     5        N� Title$  
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
   -   5         ��Name$ 	MainLabel��5      $��Zaplanuj budżet��6#   $��Center=�6=   $��233,10,228,0q�6Z   $	��Top=�6p   $	��339��6�   $��70��6�   $��48(�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ MonthBudgetGrid��5      $
��Left=�6-   {�. $��
348,85,0,0q�6Y   $	��Top=�6m   $	��316��6�   $	��375��6�   ���	#FF0099D5   AutoGenerateColumns .  
�������	   RowBackground	 �	#FFE6F2FF
   AlternatingRowBackground
 �	#FF9FCADB   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Nazwa kategorii��6%      MinWidth$	 200Q�6\      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6k      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   ��  �� Path$
 Name�6x     5      $ Recid kategorii��6%   $	 200Q�6`   $
 Auto 6o      
Visibility$ Hidden=�6|    6>   �� $ CatRecid�6|     5       $% Planowany budżet dla kategorii��6%   $	 100Q�6l   $
 Auto 6{    6M   �� $ Value�6{   5"      �� 5#   
   -   5        $ 
MonthLabel��5#      $��	Miesiąc:��6$   $��Center=�67   $��165,83,540,0q�6T   $	��Top=�6j   $��95��6�   $��14(�6�   $��Source Sans Pro)�6�   �� 5'   
   -   5        $ 	AddButton��5'      $��Zapisz budżet��6%   $
��Left=�6=   $��520,420,0,0q�6X   $	��Top=�6m   $	��203��6�   $��36��6�   ���	#FF73797F$��20(�6�   $��Cambria)�6�   ���	#FFEAEAEA���	#FF0099D56  �� 5(   
   -   5         ��Name$ MonthComboBox��5(      $
��Left=�6*   $��170,111,0,0q�6E   $	��Top=�6Z   $	��141��6r   6~   �� 5*   
   -   5        $ 	YearLabel��5*      $
��Rok:��6#   $��Center=�62   $��164,137,541,0q�6O   $	��Top=�6f   $��95��6~   $��14(�6�   $��Source Sans Pro)�6�   �� 5-   
    �� Orientation$ 
Horizontal=�6   $��164,155,480,414q�6.   .+�5.      �� -   5         ��Name$ YearBox��5.      $��5,5,0,2.667q�6A   $��95��6W   $�� ��6b    �� 
IsReadOnly . $��18(�6|   ���	#FF0099D5���	#FFE7E7E76�   �� 5/      -   5        $ cmdUp��5/      $��5,5,0,2.667q�6>   $��˄��6S   $��20��6_   ���	#FFEAEAEA���	#FF0099D56�   �� 50      -   5        $ cmdDown��50      $��0,5,0,2.667q�6@   $��˅��6V   $��20��6b   ���	#FFE7E7E7���	#FF0099D56�   51      �� 54   
   -   5        $ EarningLabel��54      $��Miesięczny przychód:��6&   $��Center=�6E   $��165,188,457,0q�6b   $	��Top=�6y   $	��178��6�   $��14(�6�   $��Source Sans Pro)�6�   �� 55   
   -   5        $ EarningsBox��55      $��170,212,457,365q�6B   $	��0,0��6[    .  $��18(�6y   ���	#FF0099D5���	#FFE6F2FF J� RenderTransformOrigin$ 0.5,0.5&�6�   6�   �� 56   
   -   5        $ IBLabel��56      $"��Kwota na budżet nieregulany��6!   $��Center=�6G   $��166,240,452,0q�6d   $	��Top=�6{   $	��182��6�   $��14(�6�   $��Source Sans Pro)�6�   �� 57   
   -   5        $ IrregularBudgetBox��57      $��171,264,457,313q�6I   $	��0,0��6b    .  $��18(�6�   ���	#FF0099D5���	#FFE6F2FF$ 0.5,0.5&�6�   6�   59      5:      