   M S B A M L   `   `   `  ����E  AHomeBudget, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HomeBudget.PanelsHomeBudget.Panels  5      %    HomeBudget.Panels.RegisterPanel   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:HomeBudget.Panels     5        N� Title$  
LoginPanel��5	       N� 
Background
 ����� N� 
FontFamily$ Source Sans Pro)�5
      .��5      � ���	#FFF6F6F6$
��Left=�6"   $	��800��6=   .+�5   
   �� -   5         ��Name$ 	MainLabel��5      $��Rejestracja��6#   $��283,10,263,0q�69   $	��Top=�6O   $	��254��6g   $��70��6s   $��48(�6   �� 5   
   -   5         ��Name$ EmailBox��5      $
��Left=�6$   $��39��6?   $��283,140,0,0q�6K    �� TextWrapping$ NoWrap=�6`   $�� ��6v   $	��Top=�6~   $	��254��6�   $��24(�6�    �� MaxLines$ 1��6�   ���	#FFE6F2FF���	#FF0099D5$��Cambria)�6�   
���   � �� SelectionBrush �	#FF0099D56  �� 5   
   -   5        $ EmailLabel2��5      $��Adres e-mail��6%   $
��Left=�6<   $��283,102,0,0q�6W   $	��Top=�6l   $	��132��6�   $��20(�6�   $��Cambria)�6�   �� 5   
   -   5        $ 
EmailLabel��5      $�� Powtórz adres e-mail��6$   $
��Left=�6D   $��283,179,0,0q�6_   $	��Top=�6t   $	��254��6�   $��20(�6�   $��Cambria)�6�   �� 5   
   -   5        $ 	EmailBox2��5      $
��Left=�6%   $��39��6@   $��283,212,0,0q�6L   $ NoWrap=�6a   $�� ��6w   $	��Top=�6   $	��254��6�   $��24(�6�   $ 1��6�   ���	#FFE6F2FF���	#FF0099D5$��Cambria)�6�   
���   � �	#FF0099D56  G� 5   
   -   5         G�Name$ PasswordBox��5      $
��Left=�6+   $��39��6F   $��283,282,0,0q�6R   $	��Top=�6i   $	��254��6�   $��24(�6�   ���	#FFE6F2FF���	#FF0099D5
���   �$��Cambria)�6�   �� 5   
   -   5        $ PasswordLabel��5      $��Hasło��6'   $
��Left=�67   $��283,249,0,0q�6R   $	��Top=�6g   $��20(�6   $��Cambria)�6�   G� 5   
   -   5        $ PasswordConfirmBox��5      $
��Left=�62   $��39��6M   $��283,354,0,0q�6Y   $	��Top=�6p   $	��254��6�   $��24(�6�   ���	#FFE6F2FF���	#FF0099D5
���   �$��Cambria)�6�   6�   �� 5   
   -	   5        $ PasswordConfirmLabel��5      $��Powtórz hasło��6.   $
��Left=�6F   $��283,321,0,0q�6a   $	��Top=�6v   $��20(�6�   $��Cambria)�6�   �� 5   
   -
   5        	 ��Name$	 RegisterButton��5      $��Zarejestruj się��6+   $
��Left=�6E   $��283,398,0,0q�6`   $	��Top=�6u   $	��254��6�   $��50��6�   ���	#FF73797F$��24(�6�   $��Cambria)�6�   ���	#FFEAEAEA���	#FF0099D56  �� 5   
   -   5        
 ��Name$
 RegisterFail��5      $
��Wrap=�6*   $�� ��6>   $
��Left=�6F   $��542,398,0,0q�6a   $	��Top=�6v   $��50��6�   $	��216��6�   $��16(�6�   ���	#FFF50A0A$��Cambria)�6�   �� 5   
   -   5        $	 LoginButton��5      $��Powrót do okna logowania��6&   $
��Left=�6I   $��344,448,0,0q�6d   $	��Top=�6y   $	��193��6�   
������ 
������ ���	#FF0099D5$��16(�6�   6�   5#      5$      