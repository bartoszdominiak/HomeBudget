   M S B A M L   `   `   `  ����E  AHomeBudget, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HomeBudget.PanelsHomeBudget.Panels  5      #    HomeBudget.Panels.AllExpenses   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:HomeBudget.Panels     5        N� Title$  
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
   -   5         ��Name$ 	MainLabel��5      $��Historia wydatków��6#   $��Center=�6?   $��216,10,162,0q�6\   $	��Top=�6r   $	��422��6�   $��70��6�   $��48(�6�   $��Source Sans Pro)�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ExpensesGrid��5      $
��Left=�6)   $��163,167,0,0q�6D   $	��Top=�6Y   $	��318��6q   $	��600��6~   ���	#FF0099D5
�������   RowBackground �	#FFE6F2FF	   AlternatingRowBackground	 �	#FF9FCADB
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Nazwa��6%      MinWidth$	 200Q�6R      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6a      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   ��  �� Path$
 Name�6n     5      $ Kwota��6%   $ 70Q�6S   $
 Auto 6a    .  64   �� $ Value�6n     5      $
 Data��6%   $ 80Q�6Q   $
 Auto 6_    .    SortDirection$ 
DescendingX�6~    63   �� $
 Date�6~     5      $ 	Kategoria��6%   $	 110Q�6^   $
 Auto 6m    .  68   �� $ CategoryName�6z     5       $ CatRecid��6%   $	 110Q�6^   $
 Auto 6m    .    
Visibility$ Hidden=�6�    67   �� $ CategoryRecid�6�     5!      $ Recid��6%   $	 110Q�6V   $
 Auto 6e    . $ Hidden=�6�    64   �� $ ExpRecid�6�   4  .System.Windows.Controls.DataGridTemplateColumn  5"         CellTemplate 5#      �� 5$      .R�5%      �� -   5        $��60��5%   C   
 � Tag$	 aaa��6Q   ���	#FFFFCA50
���   �$��Source Sans Pro)�6�   .��6�   	Modyfikuj6�   5&      5(        5)       5*      �� 5+      .R�5,      �� -   5        $	 aaa��5,   &   $��60��61   ���	#FFFFCA50
���   �$��Source Sans Pro)�6~   .��6�   Usuń6�   5-      5/      51      �� 52   
   -   5        $ label��52      $��Wybierz okres:��6   $
��Left=�68   $��
163,68,0,0q�6S   $	��Top=�6g   $	��145��6   $��16(�6�   $��Source Sans Pro)�6�   �� 53   
   -   5         ��Name$ 	DateToBox��53      $��Center=�6%   $��25��6B   $��247,134,421,0q�6N    �� TextWrapping$ NoWrap=�6e   $�� ��6{   $	��Top=�6�   $	��132��6�   $��16(�6�    �� MaxLines$ 1��6�   ���	#FFE6F2FF���	#FF0099D5$��Source Sans Pro)�6�   
���   � �� SelectionBrush �	#FF0099D56�  �� 54   
   -   5        $ DateToLabel��54      $��Data do:��6%   $��Center=�68   $��165,134,540,0q�6U   $	��Top=�6l   $��95��6�   $��14(�6�   $��Source Sans Pro)�6�   &   System.Windows.Controls.Calendar  55   
   -   5        $��
CalendarTo��55   [   $
��Left=�6   $��371,131,0,0q�6.   $	��Top=�6C   $y�Hidden=�6m   $	��164��6�   $	��193��6�   6�   �� 56   
   -   5        $ ChangeButton��56      $��Zmień okres��6(   $
��Left=�6>   $��631,123,0,0q�6Y   $	��Top=�6n   $	��132��6�   $��36��6�   ���	#FF73797F$��20(�6�   $��Cambria)�6�   ���	#FFEAEAEA���	#FF0099D5 J� RenderTransformOrigin$ -1.866,0.187&�6	  6.  �� 57   
   -   5        $ DateFromBox��57      $��Center=�6'   $��26��6D   $��247,102,421,0q�6P   $ NoWrap=�6g   $�� ��6}   $	��Top=�6�   $	��132��6�   $��16(�6�   $ 1��6�   ���	#FFE6F2FF���	#FF0099D5$��Source Sans Pro)�6�   
���   � �	#FF0099D56�  �� 58   
   -   5        $ DateFromLabel��58      $��Data od:��6'   $��Center=�6:   $��165,101,540,0q�6W   $	��Top=�6n   $��95��6�   $��14(�6�   $��Source Sans Pro)�6�     59   
   -   5        $��CalendarFrom��59   [   $
��Left=�6   $��371,100,0,0q�6.   $	��Top=�6C   $y�Hidden=�6o   $	��164��6�   $	��193��6�   6  5=      5>      