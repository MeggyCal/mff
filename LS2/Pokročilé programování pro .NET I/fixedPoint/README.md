V�sledky benchmark� pro po��t�n� ve Fixed notaci
================================================

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

Benchmarky byly spu�t�ny s defaultn�m configem (tedy bez ��dn�ho)
Platformou byl Intel s hardwarovou podporou d�len� a desetin�ch ��sel

Tabulka v�sledk�:

* Benchmarky.AddTests 
  * Q24_8Test           :  446.0400 ns 
  * Q16_16Test          :  454.3971 ns     
  * Q8_24Test           :  445.8681 ns
  * FloatTest           :  0.0097 ns         
  * DoubleTest          :  0.0953 ns    
* Benchmarky.SubtractTests          
  * Q24_8Test           :  442.8743 ns   
  * Q16_16Test          :  452.5564 ns
  * Q8_24Test           :  447.2059 ns      
  * FloatTest           :  0.0498 ns         
  * DoubleTest          :  0.0208 ns            
* Benchmarky.MultiplyTests                     
  * Q24_8Test           :  449.2814 ns       
  * Q16_16Test          :  448.9159 ns        
  * Q8_24Test           :  467.1417 ns           
  * FloatTest           :  0.0129 ns                  
  * DoubleTest          :  0.0413 ns                    
* Benchmarky.DivideTests
  * Q24_8Test           :  457.6201 ns                
  * Q16_16Test          :  475.9709 ns             
  * Q8_24Test           :  471.1466 ns         
  * FloatTest           :  0.0070 ns             
  * DoubleTest          :  0.2041 ns


 Z t�chto v�sledk� vypl�v�, �e pou�it� Fixed point typ� je ��dov�
 hor��, ne� pou��vat vestav�n� floating point typy.

 D�le m��e ��ct, �e d�len� nen� nijak v�razn� hor��,
 ne� jin� operace na tomto typu procesoru.

 D�le vyd�me, �e a�koliv benchmarky FixedPoint jsou stabiln�,
 benchmarky u float a double jsou nestabiln�,
 ba dokonce subjektivn� pochybuji o jejich spr�vnosti.

