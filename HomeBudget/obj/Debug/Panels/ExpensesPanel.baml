   M S B A M L   `   `   `  ����E  AHomeBudget, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HomeBudget.PanelsHomeBudget.Panels  5      %    HomeBudget.Panels.ExpensesPanel   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:HomeBudget.Panels     5        N� Title$  
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
��Left=�6=   $	��Top=�6X   $	��158��6p   $��61��6|   $y�Hidden=�6�   $��	0,502,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -   5         ��Name$ 	MainLabel��5      $��Nowy wydatek��6#   $��Center=�6:   $��259,10,221,0q�6W   $	��Top=�6m   $	��320��6�   $��70��6�   $��48(�6�   �� 5   
   -   5        $ CategryLabel��5      $��Nazwa kategorii��6&   $��Center=�6@   $��278,96,268,0q�6]   $	��Top=�6s   $	��254��6�   $��18(�6�   $��Source Sans Pro)�6�   �� 5   
   -   5         ��Name$ CategoryComboBox��5      $
��Left=�6-   $��31��6H   $��278,139,0,0q�6T   $	��Top=�6i   $	��254��6�   $��20(�6�   ���	#FFE6F2FF���	#FF0099D5$��Source Sans Pro)�6�   
���   �6�   �� 5    
   -   5         ��Name$ NameBox��5       $��Center=�6#   $��31��6@   $��278,213,268,0q�6L   	 �� TextWrapping$	 NoWrap=�6c   $�� ��6y   $	��Top=�6�   $	��254��6�   $��20(�6�   
 �� MaxLines$
 1��6�   ���	#FFE6F2FF���	#FF0099D5$��Source Sans Pro)�6�   
���   � �� SelectionBrush �	#FF0099D56  �� 5!   
   -   5        $ 	NameLabel��5!      $��Opis wydatku��6#   $��Center=�6:   $��278,180,386,0q�6W   $	��Top=�6n   $	��136��6�   $��18(�6�   $��Source Sans Pro)�6�   �� 5"   
   -   5        $ DateBox��5"      $��Center=�6#   $��31��6@   $��278,290,268,0q�6L   $	 NoWrap=�6c   $�� ��6y   $	��Top=�6�   $	��254��6�   $��20(�6�   $
 1��6�   ���	#FFE6F2FF���	#FF0099D5$��Source Sans Pro)�6�   
���   � �	#FF0099D56�  �� 5#   
   -   5        $ 	DateLabel��5#      $
��Data��6#   $��Center=�62   $��278,251,386,0q�6O   $	��Top=�6f   $	��136��6~   $��18(�6�   $��Source Sans Pro)�6�   �� 5$   
   -   5        $ 	AmountBox��5$      $��Center=�6%   $��31��6B   $��278,362,268,0q�6N   $	 NoWrap=�6e   $
��0,00��6{   $	��Top=�6�   $	��254��6�   $��20(�6�   $
 1��6�   ���	#FFE6F2FF���	#FF0099D5$��Source Sans Pro)�6�   
���   � �	#FF0099D56�  �� 5%   
   -   5        $ AmountLabel��5%      $��Kwota��6%   $��Center=�65   $��278,328,386,0q�6R   $	��Top=�6i   $	��136��6�   $��18(�6�   $��Source Sans Pro)�6�   &   System.Windows.Controls.Calendar  5&   
   -   5        $��Calendar��5&   [   $
��Left=�6   $��532,302,0,0q�6.   $	��Top=�6C   $y�Hidden=�6k   6�   �� 5'   
   -   5        $ 	AddButton��5'      $��Dodaj wydatek��6%   $
��Left=�6=   $��278,420,0,0q�6X   $	��Top=�6m   $	��254��6�   $��36��6�   ���	#FF73797F$��20(�6�   $��Cambria)�6�   ���	#FFEAEAEA���	#FF0099D56  �� 5)   
   -   5        $ Added��5)      $�� ��6   $
��Left=�6*   $��403,490,0,0q�6E   $	��Top=�6Z   $��50��6r   $	��248��6~   $��16(�6�   ���	#FF267D06$��Cambria)�6�   �� 5*   
   -   5        $ AddFail��5*      $�� ��6!   $
��Left=�6,   $��403,490,0,0q�6G   $	��Top=�6\   $��50��6t   $	��308��6�   $��16(�6�   ���	#FF860000$��Cambria)�6�   5-      5.      