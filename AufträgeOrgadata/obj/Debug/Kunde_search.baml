   M S B A M L   `   `   `  ����  AufträgeOrgadata$    AufträgeOrgadata.Kunde_search   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � Title$  Kunde Suche��5   	   $	��405��5   	   $	��730��5	   	    � 
ResizeMode$ NoResize=�5
   	    � Icon$ Images/search.ico��5   	    � 	Resources 5       �� 
TargetType �� Triggers P� Property P� Value �� Property	 �� Value��%  '��       '�� �    �� 5   
   " ��6    5      P� 5       �@��AlternationIndex$ 1��6C   . �5      ��  � ��	 �#FF8C0063   5      P� 5       �@��AlternationIndex$ 0��6C   . �5      ��  � ��	 �	#FFFFFFFF63   5      P� 5       �@��
IsSelected . . �5      ��  � ��
	 �   �64   5      P� 5       �@J�IsMouseOver . . �5      ��  � ��
	 �   �64   5      5      �� 5   
   " ��6   .�5      ��  � ��	 �#FF8C006+   5      5       .��5!      � .+�5"   
   �� -   5        
 ��Name$
 lvKundeSearch��5#      $��0,0,2,0q�6$    �� AlternationCount$ 2��5%      $��16(�5&      $��Time New Roman Bold)�5'      ��5$      �� *KundeFindList+ � ContextMenu 5(      �� 5)      .@�5*      m� -   5         m�Name$
 edit��5*      $��Eintrag Bearbeiten��6-   m� 5+      -   5        $ delete��5+      $��Eintrag Löschen��6/   6H   5,       �� View 5.      �� 5/      .P�50      �� $
��Name��6%    �� DisplayMemberBinding 63   �� *
NameFind+�� 51      $	��Ort��6%    62   �� *	OrtFind+�� 52      $	��Str��6%    62   �� *	StrFind+�� 53      $	��PLZ��6%    62   �� *	PLZFind+�� 54      $��Ansprechpartner��6%    6>   �� *AnsprechpartnerFind+�� 55      $��
VertragsNr��6%    69   �� *VertragsNrFind+56      58      59      5:      