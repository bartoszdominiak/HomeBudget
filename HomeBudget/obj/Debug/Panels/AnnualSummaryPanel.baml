   M S B A M L   `   `   `  ����E  AHomeBudget, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HomeBudget.PanelsHomeBudget.Panels  5      *    $HomeBudget.Panels.AnnualSummaryPanel   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:HomeBudget.Panels     5        N� Title$  
LoginPanel��5	       N� 
Background
 ����� N� 
FontFamily$ Source Sans Pro)�5      .��5      � ���	#FFF6F6F6$
��Left=�6"   $	��800��6=   .+�5   
   �� -   5         ��Name$ InterfaceButton��5      $��=��6*   $
��Left=�66   $	��Top=�6Q   $	��60 ��6i   $��60��6u   $��48(�6�   $
��Bold"�6�    � Cursor$  ��6�   ���	#FF0099D5���	#FFEAEAEA$��Source Sans Pro Light)�6�    � 5   
   -   5          �Name$ InterfaceFrame��5      $�� ��6(   $
��Left=�63   $	��600��6N   $	��Top=�6[   $	��160��6s   $y�Hidden=�6   6�   �� 5   
   -   5        $ 
MenuButton��5      $
��Menu��6%   $
��Left=�64   $	��Top=�6O   $	��158��6g   $��63��6s   $y�Hidden=�6   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -   5        $ ExpensesButton��5      $��Nowy wydatek��6)   $
��Left=�6@   $	��Top=�6[   $	��158��6s   $��63��6   $y�Hidden=�6�   $��0,63,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -   5        $ AllExpensesButton��5      $��Historia wydatków��6,   $
��Left=�6H   $	��Top=�6c   $	��158��6{   $��63��6�   $y�Hidden=�6�   $��	0,126,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -   5        $ MonthPlansButton��5      $��Zaplanuj budżet��6+   $
��Left=�6E   $	��Top=�6`   $	��158��6x   $��63��6�   $y�Hidden=�6�   $��	0,189,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -   5        $ HistoryMonthPlansButton��5      $"��Historia realizacji budżetu��62   $
��Left=�6X   $	��Top=�6s   $	��158��6�   $��62��6�   $y�Hidden=�6�   $��	0,252,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6  �� 5   
   -   5        $ CategoriesButton��5      $��Moje kategorie wydatków��6+   $
��Left=�6M   $	��Top=�6h   $	��158��6�   $��63��6�   $y�Hidden=�6�   $��	0,376,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -	   5        $ IrregularBudgetButton��5      $��Moje wydatki nieregularne��60   $
��Left=�6T   $	��Top=�6o   $	��158��6�   $��62��6�   $y�Hidden=�6�   $��	0,314,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6  �� 5   
   -
   5        $ SettingsButton��5      $��Ustawienia użytkownika��6)   $
��Left=�6J   $	��Top=�6e   $	��158��6}   $��63��6�   $y�Hidden=�6�   $��	0,439,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -   5        $ LogOutButton��5      $��Wyloguj się��6'   $
��Left=�6=   $	��Top=�6X   $	��158��6p   $��61��6|   $y�Hidden=�6�   $��	0,502,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -   5         ��Name$ 	MainLabel��5      $��Podsmowanie roczne��6#   $��Center=�6@   $��171,10,27,0q�6]   $	��Top=�6r   $	��602��6�   $��70��6�   $��48(�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ MonthBudgetGrid��5      $
��Left=�6-   {�. $��
371,85,0,0q�6Y   $	��Top=�6m   $	��316��6�   $	��352��6�   ���	#FF0099D5   AutoGenerateColumns .  
�������	   RowBackground	 �	#FFE6F2FF
   AlternatingRowBackground
 �	#FF9FCADB   Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Nazwa kategorii��6%      MinWidth$	 180Q�6\      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6k      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   ��  �� Path$
 Name�6x     5"      $ Recid kategorii��6%   $	 200Q�6`   $
 Auto 6o      
Visibility$ Hidden=�6|    6>   �� $ CatRecid�6|     5#      $ Kwota wydana��6%   $	 160Q�6X   $
 Auto 6g    6;   �� $	 Sum�6g   5%      �� 5'   
   -   5        $ 	YearLabel��5'      $
��Rok:��6#   $��Center=�62   $��166,85,539,0q�6O   $	��Top=�6e   $��95��6}   $��14(�6�   $��Source Sans Pro)�6�   �� 5*   
    �� Orientation$ 
Horizontal=�6   $��166,103,478,466q�6.   .+�5+      �� -   5         ��Name$ YearBox��5+      $��5,5,0,2.667q�6A   $��95��6V   $��25��6a   $�� ��6m    �� 
IsReadOnly . $��18(�6�   ���	#FF0099D5���	#FFE7E7E76�   �� 5,      -   5        $ cmdUp��5,      $��5,5,0,2.667q�6>   $��˄��6S   $��25��6_   $��20��6k   ���	#FF0099D5���	#FFEAEAEA6�   �� 5-      -   5        $ cmdDown��5-      $��0,5,0,2.667q�6@   $��˅��6V   $��25��6b   $��20��6n   ���	#FF0099D5���	#FFE7E7E76�   5.      �� 51   
   -   5        $ EarningLabel��51      $��Przychód roczny��6&   $��Center=�6@   $��166,133,456,0q�6]   $	��Top=�6t   $	��178��6�   $��14(�6�   $��Source Sans Pro)�6�   �� 52   
   -   5        $ EarningsBox��52      $��171,157,534,420q�6B   $	��0,0��6[    .  $��18(�6y   ���	#FF0099D5���	#FFE7E7E7 J� RenderTransformOrigin$ 0.5,0.5&�6�   ���	#FF1483006�   �� 53   
   -   5        $ AllExpensesLabel��53      $��Wydatki roczne��6*   $��Center=�6C   $��166,180,452,0q�6`   $	��Top=�6w   $	��182��6�   $��14(�6�   $��Source Sans Pro)�6�   �� 54   
   -   5        $ AllExpensesBox��54      $��171,204,534,373q�6E   $	��0,0��6^    .  $��18(�6|   ���	#FF0099D5���	#FFE7E7E7$ 0.5,0.5&�6�   ���	#FFF21E1E6�   �� 55   
   -   5        $ IBPlusLabel��55      $%��Fundusz na wydatki nieregularne��6%   $��Center=�6O   $��165,228,429,0q�6l   $	��Top=�6�   $	��206��6�   $��14(�6�   $��Source Sans Pro)�6�   �� 56   
   -   5        $ IrregularBudgetPlusBox��56      $��171,255,535,322q�6L   $	��0,0��6e    .  $��18(�6�   ���	#FF0099D5���	#FFE7E7E7$ 0.5,0.5&�6�   ���	#FF1483006�   �� 57   
   -   5        $ IBLabelMinusLabel��57      $��Wydatki nieregularne��6+   $��Center=�6J   $��166,273,428,0q�6g   $	��Top=�6~   $	��206��6�   $��14(�6�   $��Source Sans Pro)�6�   �� 58   
   -   5        $ IrregularBudgetMinusBox��58      $��172,300,534,277q�6M   $	��0,0��6f    .  $��18(�6�   ���	#FF0099D5���	#FFE7E7E7$ 0.5,0.5&�6�   ���	#FFF21E1E6�   �� 59   
   -   5        $ SavingsLabel��59      $"��W ciągu roku zaoszczędzono��6&   $��Center=�6K   $��166,323,428,0q�6h   $	��Top=�6   $	��206��6�   $��14(�6�   $��Source Sans Pro)�6�   $
��Bold"�6�   �� 5:   
   -   5        $ 
SavingsBox��5:      $��172,350,534,227q�6A   $	��0,0��6Z    .  $��18(�6x   ���	#FF0099D5���	#FFE7E7E7$ 0.5,0.5&�6�   ���	#FF1483006�   5=      5>      