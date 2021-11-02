using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PigLatinUnitTest
{
    public class TestPigLatin
    {
       
        [Fact]
        public void IsVowelFirstLetter()
        {
            //Arrange
           Translator t = new Translator();
           string expected = "appleway";

            //Act                                                       //fails
            string actual = t.ToPigLatin("apple", "");
       

            //Assert 
            Assert.Equal(expected, actual);

        }



        [Theory]
        [InlineData("apple", "appleway")]
        [InlineData("heck", "eckhay")]
        [InlineData("strong", "ongstray")]
        [InlineData("tommy@email.com", "tommy@email.com")]
        [InlineData("aardvark", "aardvarkway")]
        [InlineData("Tommy", "ommytay")]
        [InlineData("gym", "gym")]
        [InlineData("apple joy gym tommy@email.com strong", "appleway oyjay gym tommy@email.com ongstray")]


        public void PigLatinTheory(string input, string expected)
        {

            //Arrange
            Translator t = new Translator();

            //Act 
            string actual = t.ToPigLatin(input, "");

            //Assert 
            Assert.Equal(expected, actual);

        }

    }
}



//("apple", "appleway!")--Starts with vowel - Adds word + ay -Not word + way--Added a w           
//("heck", "eckhay")
//("strong", "ongstray")
//("tommy@email.com", "tommy@email.com")-Worked with no errors because of @ special character       ***
//("aardvark", "aardvarkway")-Starts with vowel - Adds word + ay -Not word + way--Added a w        
//("Tommy", "ommytay")
//("gym", "gym")-Worked with no errors                                                              ***
//("apple joy gym tommy@email.com strong", "appleway oyjay gym tommy@email.com ongstray")