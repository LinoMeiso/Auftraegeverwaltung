   M S B A M L   `   `   `  ����  AufträgeOrgadata    AufträgeOrgadata.Kunde   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � Title$  Kunde��5   	   $	��440��5   	   $
��1015��5	   	    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$ Images/costumers.ico��5   	    � 	Resources 5       �� 
TargetType �� Triggers P� Property P� Value �� Property	 �� Value��%  '��       '�� �    �� 5   
   " ��6    5      P� 5       �@��AlternationIndex$ 1��6C   . �5      ��  � ��	 �#FF8C0063   5      P� 5       �@��AlternationIndex$ 0��6C   . �5      ��  � ��	 �	#FFFFFFFF63   5      P� 5       �@��
IsSelected . . �5      ��  � ��
	 �   �64   5      P� 5       �@J�IsMouseOver . . �5      ��  � ��
	 �   �64   5      5      �� 5   
   " ��6   .�5      ��  � ��	 �#FF8C006+   5       5!      .��5#      � .+�5$   
   o� -   5        
 o�Name$
 	menuKunde��5$      $��0,0,0,0q�6"   $��25��63   $
��1009��6?   $	��Top=�6L   $
��Left=�6d   
�������.@�5%      m� -   5         m�Name$
 data��5%      $��Datei��6%   $��25��64   .@�5&      m� -   5        $	 add��5&      $��Eintrag Hinzufügen��6(   $��25��6D    m� Icon 5'      �� 5(      $��16��6    $��16��6+   $��Images\add.ico��67   5*      m� 5+      -   5        $
 edit��5+      $��Eintrag Bearbeiten��6)   $��25��6E    5,      �� 5-      $��16��6    $��16��6+   $��Images\edit.ico��67   5/      m� 50      -   5        $ delete��50      $��Eintrag Löschen��6+   $��25��6D    51      �� 52      $��16��6    $��16��6+   $��Images\delete.ico��67   54      m� 55      -   5        $ search��55      $��Eintrag Suchen��6+   $��25��6C    56      �� 57      $��16��6    $��16��6+   $��Images\search.ico��67   59      �� 5:      m� 5;      -   5        $ close��5;      $��
Schließen��6*   $��25��6=    5<      �� 5=      $��16��6    $��16��6+   $��Images\close_red.ico��67   5?      5@      5A      �� 5C   
   -	   5         ��Name$ lvKunde��5C      $��0,25,0,0q�6$    �� AlternationCount$ 2��5E      $��16(�6(   $��Time New Roman Bold)�66   ��5D      �� *
KundeListe+ � ContextMenu 5F      �� 5G      .@�5H      m� -
   5        $ 	eintragen��5H      $��Eintrag eintragen��62   6M   5I       �� View 5K      �� 5L      .P�5M      �� $
��Name��6%    �� DisplayMemberBinding 63   �� *Name+�� 5N      $	��Ort��6%    62   �� *Ort+�� 5O      $	��Str��6%    62   �� *Str+�� 5P      $	��PLZ��6%    62   �� *PLZ+�� 5Q      $��Ansprechpartner��6%    6>   �� *Ansprechpartner+�� 5R      $��
VertragsNr��6%    69   �� *
VertragsNr+5S      5U      5W      5X      