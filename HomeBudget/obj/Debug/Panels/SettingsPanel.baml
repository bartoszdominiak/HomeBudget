   M S B A M L   `   `   `  ����E  AHomeBudget, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HomeBudget.PanelsHomeBudget.Panels  5      %    HomeBudget.Panels.SettingsPanel   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:HomeBudget.Panels     5        N� Title$  
LoginPanel��5	       N� 
Background
 ����� N� 
FontFamily$ Source Sans Pro)�5
      .��5      � ���	#FFF6F6F6$
��Left=�6"   $	��800��6=   .+�5   
   �� -   5         ��Name$ InterfaceButton��5      $��=��6*   $
��Left=�66   $	��Top=�6Q   $	��60 ��6i   $��60��6u   $��48(�6�   $
��Bold"�6�    � Cursor$  ��6�   ���	#FF0099D5���	#FFEAEAEA$��Source Sans Pro Light)�6�    � 5   
   -   5          �Name$ InterfaceFrame��5      $�� ��6(   $
��Left=�63   $	��600��6N   $	��Top=�6[   $	��160��6s   $y�Hidden=�6   6�   �� 5   
   -   5        $ 
MenuButton��5      $
��Menu��6%   $
��Left=�64   $	��Top=�6O   $	��158��6g   $��63��6s   $y�Hidden=�6   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -   5        $ ExpensesButton��5      $��Nowy wydatek��6)   $
��Left=�6@   $	��Top=�6[   $	��158��6s   $��63��6   $y�Hidden=�6�   $��0,63,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -   5        $ AllExpensesButton��5      $��Historia wydatków��6,   $
��Left=�6H   $	��Top=�6c   $	��158��6{   $��63��6�   $y�Hidden=�6�   $��	0,126,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -   5        $ MonthPlansButton��5      $��Zaplanuj budżet��6+   $
��Left=�6E   $	��Top=�6`   $	��158��6x   $��63��6�   $y�Hidden=�6�   $��	0,189,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -   5        $ HistoryMonthPlansButton��5      $"��Historia realizacji budżetu��62   $
��Left=�6X   $	��Top=�6s   $	��158��6�   $��62��6�   $y�Hidden=�6�   $��	0,252,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6  �� 5   
   -   5        $ CategoriesButton��5      $��Moje kategorie wydatków��6+   $
��Left=�6M   $	��Top=�6h   $	��158��6�   $��63��6�   $y�Hidden=�6�   $��	0,376,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -	   5        $ IrregularBudgetButton��5      $��Moje wydatki nieregularne��60   $
��Left=�6T   $	��Top=�6o   $	��158��6�   $��62��6�   $y�Hidden=�6�   $��	0,314,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6  �� 5   
   -
   5        $ SettingsButton��5      $��Ustawienia użytkownika��6)   $
��Left=�6J   $	��Top=�6e   $	��158��6}   $��63��6�   $y�Hidden=�6�   $��	0,439,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -   5        $ LogOutButton��5      $��Wyloguj się��6'   $
��Left=�6=   $	��Top=�6X   $	��158��6p   $��61��6|   $y�Hidden=�6�   $��	0,502,0,0q�6�   ���	#FF0099D5���	#FFEAEAEA6�   �� 5   
   -   5        $��Border1��5      ���	#FF0099D5$��1q�68   $
��Left=�6L   $	��185��6g   $��
168,71,0,0q�6t   $	��Top=�6�   $	��559��6�   �� 5   
   -   5         ��Name$ 	MainLabel��5      $��Ustawienia użytkownika��6#   $��Center=�6D   $��208,10,201,0q�6a   $	��Top=�6w   $	��391��6�   $��70��6�   $��36(�6�   �� 5   
   -   5        $ 
Info1Label��5      $$��Ustawienia szybkiego dostępu:��6$   $
��Left=�6L   $��
188,80,0,0q�6g   $	��Top=�6{   $
��Bold"�6�   $��14(�6�   $	��213��6�   �� 5   
   -   5        $ StartsSavingBoxLabel��5      $;��5Wartość oszczędności przy pierwszym uruchomieniu:��6.   $
��Left=�6j   $��188,107,0,0q�6�   $	��Top=�6�   �� 5   
   -   5         ��Name$ StartsSavingBox��5      $
��Left=�6+   ���	#FF0099D5$��23��6^   $��480,107,0,0q�6j    �� TextWrapping$ NoWrap=�6   $	��0,0��6�   $	��Top=�6�   $��98��6�   $��18(�6�   ���	#FFE6F2FF6�   �� 5   
   -   5        $ EarningsLabel��5      $+��%Wysokość miesięcznych przychodów:��6'   $
��Left=�6S   $��188,130,0,0q�6n   $	��Top=�6�   �� 5    
   -   5        $ EarningsBox��5       $
��Left=�6(   ���	#FF0099D5$��23��6[   $��480,132,0,0q�6g   $ NoWrap=�6|   $	��0,0��6�   $	��Top=�6�   $��98��6�   $��18(�6�   ���	#FFE6F2FF6�   �� 5!   
   -   5        $ ComboBoxLabel��5!      $$��Domyślna kategoria wydatków:��6'   $
��Left=�6N   $��188,155,0,0q�6i   $	��Top=�6~   �� 5"   
   -   5        	 ��Name$	 CategoryComboBox��5"      $
��Left=�6-   $��23��6H   $��426,157,0,0q�6T   $	��Top=�6i   $	��152��6�   $��16(�6�   ���	#FFE6F2FF���	#FF0099D5$��Source Sans Pro)�6�   
���   �6�   �� 5#   
   -   5        $ UpdateButton��5#      $��Zapisz zmiany��6(   $
��Left=�6@   $��515,204,0,0q�6[   $	��Top=�6p   $	��199��6�   $��36��6�   ���	#FF73797F$��20(�6�   $��Cambria)�6�   ���	#FFEAEAEA���	#FF0099D56  �� 5%   
   -   5        $��Border2��5%      ���	#FF0099D5$��1q�68   $
��Left=�6L   $	��185��6g   $��168,280,0,0q�6t   $	��Top=�6�   $	��559��6�   �� 5&   
   -   5        $ 
Info2Label��5&      $��Ustawienia hasła:��6$   $
��Left=�6@   $��188,292,0,0q�6[   $	��Top=�6p   $
��Bold"�6�   $��14(�6�   $��27��6�   
 J� RenderTransformOrigin$
 0.5,0.5&�6�   $	��212��6�   �� 5'   
   -   5        $ OldPasswordBoxLabel��5'      $��Stare hasło:��6-   $
��Left=�6D   $��188,315,0,0q�6_   $	��Top=�6t   $	��119��6�   G� 5(   
   -   5         G�Name$ OldPasswordBox��5(      $
��Left=�6.   ���	#FF0099D5$��25��6a   $��307,315,0,0q�6m   $	��Top=�6�   $	��151��6�   $��18(�6�   ���	#FFE6F2FF6�   �� 5)   
   -   5        $ NewPasswordBoxLabel��5)      $��Nowe hasło:��6-   $
��Left=�6C   $��188,345,0,0q�6^   $	��Top=�6s   $	��119��6�   G� 5*   
   -   5        $ NewPasswordBox��5*      $
��Left=�6.   ���	#FF0099D5$��25��6a   $��307,345,0,0q�6m   $	��Top=�6�   $	��151��6�   $��18(�6�   ���	#FFE6F2FF6�   �� 5+   
   -   5        $ NewPasswordBoxLabel2��5+      $��Powtórz hasło:��6.   $
��Left=�6G   $��188,376,0,0q�6b   $	��Top=�6w   $	��119��6�   G� 5,   
   -   5        $ NewPasswordBox2��5,      $
��Left=�6/   ���	#FF0099D5$��25��6b   $��307,376,0,0q�6n   $	��Top=�6�   $	��151��6�   $��18(�6�   ���	#FFE6F2FF6�   �� 5.   
   -   5        $ UpdatePassword��5.      $��Zmień hasło��6*   $
��Left=�6@   $��515,412,0,0q�6[   $	��Top=�6p   $	��199��6�   $��36��6�   ���	#FF73797F$��20(�6�   $��Cambria)�6�   ���	#FFEAEAEA���	#FF0099D56  52      53      