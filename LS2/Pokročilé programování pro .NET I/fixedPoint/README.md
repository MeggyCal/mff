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

## prvn� b�h
* Benchmarky.AddTests
  *    Q24_8Test           :  456.6098 ns
  *    Q16_16Test          :  444.5341 ns
  *    Q8_24Test           :  470.4036 ns
  *    FloatTest           :  0.0391 ns
  *    DoubleTest          :  0.0387 ns
* Benchmarky.SubtractTests
  *    Q24_8Test           :  442.0263 ns
  *    Q16_16Test          :  442.6848 ns
  *    Q8_24Test           :  448.5160 ns
  *    FloatTest           :  0.0405 ns
  *    DoubleTest          :  0.0303 ns
* Benchmarky.MultiplyTests
  *    Q24_8Test           :  444.9907 ns
  *    Q16_16Test          :  444.6477 ns
  *    Q8_24Test           :  449.4225 ns
  *    FloatTest           :  0.0271 ns
  *    DoubleTest          :  0.0141 ns
* Benchmarky.DivideTests
  *    Q24_8Test           :  454.4039 ns
  *    Q16_16Test          :  466.1081 ns
  *    Q8_24Test           :  457.4034 ns
  *    FloatTest           :  0.0368 ns
  *    DoubleTest          :  0.0388 ns
* Benchmarky.GauseEliminationTests
  *    Q24_8Test           :  322.60 us
  *    Q16_16Test          :  322.40 us
  *    Q8_24Test           :  330.52 us
  *    DoubleTest          :  28.30 us


Prvn� �ty�i skupiny test� byly zam��eny na jednotliv� operace
Posledn� skupina na pou�it� v komplexn�j��m �e�en�

Pom�ry mezi v�sledky �ist�ch operac� a komplexn�ho �e�en�
jsou ��dov� rozd�ln�
**pom�r 10000 oproti 10** tedy mus� m�t n�jakou p���inu.

V testech na operace se nach�z� deklarace a jedin� operace.
Tud� m��eme ��ct, �e nejv�ce �asu n�m zab�r�
ona deklarace prom�n�ch typu FixedPoint.


Testy jsem tedy p�ed�lal a **deklaraci "vyndal" mimo test**.

## druh� b�h
* Benchmarky.AddTestsWithoutDeclaration
  *    Q24_8Test           :  170.8000 ns
  *    Q16_16Test          :  185.1193 ns
  *    Q8_24Test           :  165.4359 ns
  *    FloatTest           :  0.0357 ns
  *    DoubleTest          :  0.0418 ns

Po takov�to �prav� ji� m�me re�ln� benchmarky �ist� operac�.
**Rozd�l se sn�il**, ale st�le by �lo testovat �ist� operace l�pe.

Zkusme izolovat danou operaci zv��en�m po�tu opakov�n�.


## t�et� b�h
* Benchmarky.AddTestsWithoutDeclarationForCycle
  *    Q24_8Test           :  1,668.693 us
  *    Q16_16Test          :  1,620.104 us
  *    Q8_24Test           :  1,632.980 us
  *    FloatTest           :  6.456 us
  *    DoubleTest          :  10.239 us

Opakov�ch bylo nastaveno *10000* a z v�slek� pozorujeme
**stabilitu typu FP** a naopak ne�ekan� **zpomalen� pro
typy float a double**, kter� se p�i vysok�m po�tu opakov�n�
st�vaj� a� 20x m�n� efektivn�.

# Z�v�r
 Z celkov�ch v�sledk� vypl�v�, �e pou�it� Fixed point typ� je **��dov�
 hor��**, ne� pou��vat vestav�n� floating point typy.

 D�le m��eme ��ct, �e **d�len� nen� nijak v�razn� hor��**,
 ne� jin� operace na tomto typu procesoru.

 D�le vyd�me, �e a�koliv benchmarky FixedPoint jsou stabiln�,
 benchmarky u float a double jsou **nestabiln�** a testy 
 u t�chto typ� maj� vyskou m�ru �umu.



 # Zdroje
 [gausova eliminace (Licenced CPOL)](https://www.codeproject.com/Tips/388179/Linear-Equation-Solver-Gaussian-Elimination-Csharp)