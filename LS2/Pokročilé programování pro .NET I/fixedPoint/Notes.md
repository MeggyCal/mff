V�sledky benchmark� pro po��t�n� ve Fixed notaci
================================================

# specifikace
Porovn�valy se tyto datov� typy:
* Q24_8
* Q16_16
* Q8_24
* Float
* Double

Porovn�vali se tyto operace:
* S��t�n�
* Od��t�n�
* N�soben�
* D�len�
* Gausova eliminace

Benchmarky byly spu�t�ny s defaultn�m configem (tedy bez ��dn�ho)
Platformou byl Intel s hardwarovou podporou d�len� a desetin�ch ��sel


# v�sledky test�

|                                         	|    Q24_8    	| Q16_16      	| Q8_24       	| Float     	| Double    	|
|:---------------------------------------:	|:-----------:	|-------------	|-------------	|-----------	|-----------	|
|                 AddTests                	| 260.3110 ns 	| 263.5006 ns 	| 266.6582 ns 	| 0.0388 ns 	| 0.0422 ns 	|
|              SubtractTests              	| 264.3520 ns 	| 264.3670 ns 	| 266.9845 ns 	| 0.0238 ns 	| 0.0155 ns 	|
|              MultiplyTests              	| 262.7965 ns 	| 262.1757 ns 	| 266.3476 ns 	| 0.0577 ns 	| 0.0376 ns 	|
|               DivideTests               	| 272.6980 ns 	| 285.5533 ns 	| 271.6650 ns 	| 0.0089 ns 	| 0.0204 ns 	|
|        AddTestsWithoutDeclaration       	|  94.3261 ns 	|  96.7004 ns 	|  87.4589 ns 	| 0.0019 ns 	| 0.0078 ns 	|
|    AddTestsWithoutDeclarationForCycle   	| 99,859.3 ns 	| 90,994.1 ns 	| 87,650.3 ns 	|  593.0 ns 	|  596.3 ns 	|
| SubtractTestsWithoutDeclarationForCycle 	| 94,394.8 ns 	| 90,432.1 ns 	| 87,801.4 ns 	|  592.2 ns 	|  612.9 ns 	|
| MultiplyTestsWithoutDeclarationForCycle 	| 99,357.3 ns 	| 90,735.2 ns 	| 88,476.7 ns 	|  596.7 ns 	|  579.3 ns 	|
|  DivideTestsWithoutDeclarationForCycle  	|   98.131 us 	|   98.907 us 	|   91.472 us 	|  1.133 us 	|  1.138 us 	|
|         **GauseEliminationTests**     	|   234.09 us 	|   243.65 us 	|   242.82 us 	|  97.16 us 	|  42.41 us 	|



Prvn� �ty�i skupiny test� byly zam��eny na jednotliv� operace
Posledn� skupina na pou�it� v komplexn�j��m �e�en�

Pom�ry mezi v�sledky �ist�ch operac� a komplexn�ho �e�en�
jsou ��dov� rozd�ln�
**pom�r 10000 oproti 10** tedy mus� m�t n�jakou p���inu.

V testech na operace se nach�z� deklarace a jedin� operace.
Tud� m��eme ��ct, �e nejv�ce �asu n�m zab�r�
ona deklarace prom�n�ch typu FixedPoint.


V testu "AddTestsWithoutDeclaration" byly odebr�ny deklarace a
byly um�st�ny p�ed metody a tud� se nepo��tali do �asu.
**Rozd�l se sn�il**, ale st�le by �lo testovat �ist� operace l�pe.
Zkusme izolovat danou operaci zv��en�m po�tu opakov�n�.


Opakov�ch bylo nastaveno *1000* a z v�slek� pozorujeme
**stabilitu typu FP** a naopak **zpomalen� pro
typy float a double**, kter� se p�i vysok�m po�tu opakov�n�
st�vaj� a� 20x m�n� efektivn�. Co� je d�no t�m, �e samotn� for cyklus 
v sob� obsahuje p�i��t�n� a porovn�n�.



# Z�v�r
 Z celkov�ch v�sledk� vypl�v�, �e pou�it� Fixed point typ� je **��dov�
 hor��**, ne� pou��vat vestav�n� floating point typy.

 D�le m��eme ��ct, �e **d�len� nen� nijak v�razn� hor��**,
 ne� jin� operace na tomto typu procesoru.




 # Zdroje
 [gausova eliminace (Licenced CPOL)](https://www.codeproject.com/Tips/388179/Linear-Equation-Solver-Gaussian-Elimination-Csharp)