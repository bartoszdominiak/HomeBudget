   M S B A M L   `   `   `  ����E  AHomeBudget, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HomeBudget.PanelsHomeBudget.Panels  5      '    !HomeBudget.Panels.CategoriesPanel   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:HomeBudget.Panels     5        N� Title$  
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
   -   5         ��Name$ 	MainLabel��5      $��Kategorie wydatków��6#   $��Center=�6@   $��198,7,140,0q�6]   $	��Top=�6r   $	��462��6�   $��70��6�   $��48(�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ CategoryGrid��5      $
��Left=�6)   $��
165,79,0,0q�6D   $	��Top=�6X   $	��254��6p   $	��601��6}   ���	#FF0099D5
�������   RowBackground �	#FFE6F2FF	   AlternatingRowBackground	 �	#FF9FCADB
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Nazwa��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6S      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   ��  �� Path$
 Name�6_     5      $
 Opis��6%   $	 360 6U    .  63   �� $ Descript�6a     5      $ Kolor��6%   $ 80 6T    .    
Visibility$ Hidden=�6q    64   �� $ Color�6q   4  .System.Windows.Controls.DataGridTemplateColumn  5          CellTemplate 5!      �� 5"      .R�5#      �� -   5        $��60��5#   B   
 � Tag$	 aaa��6P   ���	#FFFFCA50
���   �$��Source Sans Pro)�6�   .��6�   	Modyfikuj6�   5$      5&        5'       5(      �� 5)      .R�5*      �� -   5        $	 aaa��5*   &   $��60��6M   ���	#FFFFCA50
���   �$��Source Sans Pro)�6�   .��6�   Usuń6�   5+      5-      5/      �� 51   
   -   5        $ 
Info5Label��51      $��Nazwa kategorii��6$   $
��Left=�6>   $��221,333,0,0q�6Y   $	��Top=�6n    J� RenderTransformOrigin$ -4.86,-0.543&�6�   $	��125��6�   $��16(�6�   $��Source Sans Pro)�6�   �� 52   
   -   5        $ 
Info6Label��52      $��Opis kategorii��6$   $
��Left=�6=   $��412,333,0,0q�6X   $	��Top=�6m   $ -4.86,-0.543&�6�   $	��110��6�   $��16(�6�   $��Source Sans Pro)�6�   �� 53   
   -   5        $ 
Info7Label��53      $��Kolor��6$   $
��Left=�64   $��160,333,0,0q�6O   $	��Top=�6d   $ -4.86,-0.543&�6|   $��56��6�   $��16(�6�   $��Source Sans Pro)�6�   �� 56   
   -   5         ��Name$ NameCategory1��56      $
��Left=�6)   ���	#FF0099D5$��30��6\   $��221,360,0,0q�6h    �� TextWrapping$ NoWrap=�6}   $�� ��6�   $	��Top=�6�   $	��163��6�   $��18(�6�   ���	#FFE6F2FF6�   �� 57   
   -   5        $ DescriptionCategory1��57      $
��Left=�60   ���	#FF0099D5$��60��6c   $��412,360,0,0q�6o   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��354��6�   $��18(�6�   ���	#FFE6F2FF6�   �� 58   
   -   5        $ ColorCategory1��58      $�� ��6)   $
��Left=�64   $��165,360,0,0q�6O   $	��Top=�6d   $��32��6|   $��30��6�   ���	#FFFFFF00���	#FF0099D56�   �� 59   
   -   5         ��Name$ 
colorList1��59   �   $��Stretch=�6   $��Stretch=�61   $��166,390,560,110q�6M   $	��100��6f   $��Visible=�6s   $��Disabled=�6�   $y�Hidden=�6   $ 0.5,0.5&�64  z�5:      V� 5;      .~�5<      �� �� 5=      �� 5>       �� Angle$ -0.414Q�6&   T� 5?      5@      ��5B      �� 5C      .R�5D      �  K� IsItemsHost .  � Orientation$ Vertical=�63   5E      ��5G      �� 5H      .R�5I      �� $��20��66   $��20��6A   ���	#FF211E1E J� OpacityMask
 �   �$��1��6t   ��6    �� *Name+6t   5J      5L      �� 5P   
   -   5        $ 	AddButton��5P      $��Dodaj nową kategorię��6%   $
��Left=�6D   $��512,425,0,0q�6_   $	��Top=�6t   $	��254��6�   $��36��6�   ���	#FF73797F$��20(�6�   $��Cambria)�6�   ���	#FFEAEAEA���	#FF0099D56  �� 5Q   
   -   5        $ ModifyButton��5Q      $��Zapisz modyfikację��6(   $
��Left=�6E   $��525,425,0,0q�6`   $	��Top=�6u   $	��254��6�   $��36��6�   ���	#FF73797F$��20(�6�   $��Cambria)�6�   ���	#FFEAEAEA���	#FF0099D5$y�Hidden=�6,  �� 5S   
   -   5        $ ChangeButton��5S      $��Przywróć dodawanie��6(   $
��Left=�6E   $��243,425,0,0q�6`   $	��Top=�6u   $	��254��6�   $��36��6�   ���	#FF73797F$��20(�6�   $��Cambria)�6�   ���	#FFEAEAEA���	#FF0099D5$y�Hidden=�6+  5X      5Y      