using System;
using Xunit;

namespace ContactBook.Tests;

public class ContactTests
{
    #region Constructor Tests

    [Fact]
    public void Constructor_WithDefaultValues_ShouldCreateEmptyContact()
    {
        // Arrange & Act
        var contact = new Contact();

        // Assert
        Assert.Equal("", contact.GetFName());
        Assert.Equal("", contact.GetLName());
        Assert.Equal("", contact.GetPhone());
        Assert.Equal("", contact.GetEmail());
    }

    [Fact]
    public void Constructor_WithValidValues_ShouldCreateContactWithValues()
    {
        // Arrange
        string fname = "John";
        string lname = "Doe";
        string phone = "555-1234";
        string email = "john@example.com";

        // Act
        var contact = new Contact(fname, lname, phone, email);

        // Assert
        Assert.Equal(fname, contact.GetFName());
        Assert.Equal(lname, contact.GetLName());
        Assert.Equal(phone, contact.GetPhone());
        Assert.Equal(email, contact.GetEmail());
    }

    [Fact]
    public void Constructor_WithPartialValues_ShouldSetProvidedValuesAndEmptyForOthers()
    {
        // Arrange & Act
        var contact = new Contact(fname: "Jane", phone: "555-5678");

        // Assert
        Assert.Equal("Jane", contact.GetFName());
        Assert.Equal("", contact.GetLName());
        Assert.Equal("555-5678", contact.GetPhone());
        Assert.Equal("", contact.GetEmail());
    }

    #endregion

    #region Getter and Setter Tests

    [Fact]
    public void SetFName_ShouldUpdateFirstName()
    {
        // Arrange
        var contact = new Contact();
        string expectedName = "Alice";

        // Act
        contact.SetFName(expectedName);

        // Assert
        Assert.Equal(expectedName, contact.GetFName());
    }

    [Fact]
    public void SetLName_ShouldUpdateLastName()
    {
        // Arrange
        var contact = new Contact();
        string expectedName = "Smith";

        // Act
        contact.SetLName(expectedName);

        // Assert
        Assert.Equal(expectedName, contact.GetLName());
    }

    [Fact]
    public void SetPhone_ShouldUpdatePhoneNumber()
    {
        // Arrange
        var contact = new Contact();
        string expectedPhone = "555-9999";

        // Act
        contact.SetPhone(expectedPhone);

        // Assert
        Assert.Equal(expectedPhone, contact.GetPhone());
    }

    [Fact]
    public void SetEmail_ShouldUpdateEmailAddress()
    {
        // Arrange
        var contact = new Contact();
        string expectedEmail = "test@example.com";

        // Act
        contact.SetEmail(expectedEmail);

        // Assert
        Assert.Equal(expectedEmail, contact.GetEmail());
    }

    [Fact]
    public void MultipleSetters_ShouldUpdateAllPropertiesCorrectly()
    {
        // Arrange
        var contact = new Contact("Old", "Old", "Old", "Old");
        string newFname = "NewFirst";
        string newLname = "NewLast";
        string newPhone = "NewPhone";
        string newEmail = "NewEmail";

        // Act
        contact.SetFName(newFname);
        contact.SetLName(newLname);
        contact.SetPhone(newPhone);
        contact.SetEmail(newEmail);

        // Assert
        Assert.Equal(newFname, contact.GetFName());
        Assert.Equal(newLname, contact.GetLName());
        Assert.Equal(newPhone, contact.GetPhone());
        Assert.Equal(newEmail, contact.GetEmail());
    }

    #endregion

    #region ToString Tests

    [Fact]
    public void ToString_WithAllValuesSet_ShouldReturnFormattedString()
    {
        // Arrange
        var contact = new Contact("John", "Doe", "555-1234", "john@example.com");
        string expected = "Contact[fname = John, lname = Doe, phone = 555-1234, email = john@example.com]";

        // Act
        string result = contact.ToString();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToString_WithEmptyContact_ShouldReturnFormattedStringWithEmptyValues()
    {
        // Arrange
        var contact = new Contact();
        string expected = "Contact[fname = , lname = , phone = , email = ]";

        // Act
        string result = contact.ToString();

        // Assert
        Assert.Equal(expected, result);
    }

    #endregion

    #region Equals Tests

    [Fact]
    public void Equals_SameReference_ShouldReturnTrue()
    {
        // Arrange
        var contact = new Contact("John", "Doe", "555-1234", "john@example.com");
        var sameReference = contact;

        // Act & Assert
        Assert.True(contact.Equals(sameReference));
    }

    [Fact]
    public void Equals_IdenticalContacts_ShouldReturnTrue()
    {
        // Arrange
        var contact1 = new Contact("John", "Doe", "555-1234", "john@example.com");
        var contact2 = new Contact("John", "Doe", "555-1234", "john@example.com");

        // Act & Assert
        Assert.True(contact1.Equals(contact2));
        Assert.True(contact2.Equals(contact1));
    }

    [Fact]
    public void Equals_DifferentContacts_ShouldReturnFalse()
    {
        // Arrange
        var contact1 = new Contact("John", "Doe", "555-1234", "john@example.com");
        var contact2 = new Contact("Jane", "Smith", "555-5678", "jane@example.com");

        // Act & Assert
        Assert.False(contact1.Equals(contact2));
        Assert.False(contact2.Equals(contact1));
    }

    [Theory]
    [InlineData("Jane", "Doe", "555-1234", "john@example.com")] // Different first name
    [InlineData("John", "Smith", "555-1234", "john@example.com")] // Different last name
    [InlineData("John", "Doe", "555-9999", "john@example.com")] // Different phone
    [InlineData("John", "Doe", "555-1234", "different@example.com")] // Different email
    public void Equals_ContactsWithOneDifferentField_ShouldReturnFalse(string fname, string lname, string phone, string email)
    {
        // Arrange
        var contact1 = new Contact("John", "Doe", "555-1234", "john@example.com");
        var contact2 = new Contact(fname, lname, phone, email);

        // Act & Assert
        Assert.False(contact1.Equals(contact2));
    }

    [Fact]
    public void Equals_NullContact_ShouldReturnFalse()
    {
        // Arrange
        var contact = new Contact("John", "Doe", "555-1234", "john@example.com");

        // Act & Assert
        Assert.False(contact.Equals(null));
    }

    [Fact]
    public void Equals_DifferentType_ShouldReturnFalse()
    {
        // Arrange
        var contact = new Contact("John", "Doe", "555-1234", "john@example.com");
        var differentType = "Not a contact";

        // Act & Assert
        Assert.False(contact.Equals(differentType));
    }

    #endregion

    #region Object.Equals Tests

    [Fact]
    public void ObjectEquals_IdenticalContacts_ShouldReturnTrue()
    {
        // Arrange
        var contact1 = new Contact("John", "Doe", "555-1234", "john@example.com");
        var contact2 = new Contact("John", "Doe", "555-1234", "john@example.com");

        // Act & Assert
        Assert.True(contact1.Equals((object)contact2));
    }

    [Fact]
    public void ObjectEquals_DifferentContacts_ShouldReturnFalse()
    {
        // Arrange
        var contact1 = new Contact("John", "Doe", "555-1234", "john@example.com");
        var contact2 = new Contact("Jane", "Smith", "555-5678", "jane@example.com");

        // Act & Assert
        Assert.False(contact1.Equals((object)contact2));
    }

    [Fact]
    public void ObjectEquals_NullObject_ShouldReturnFalse()
    {
        // Arrange
        var contact = new Contact("John", "Doe", "555-1234", "john@example.com");

        // Act & Assert
        Assert.False(contact.Equals((object)null));
    }

    #endregion

    #region Operator Overload Tests

    [Fact]
    public void EqualityOperator_IdenticalContacts_ShouldReturnTrue()
    {
        // Arrange
        var contact1 = new Contact("John", "Doe", "555-1234", "john@example.com");
        var contact2 = new Contact("John", "Doe", "555-1234", "john@example.com");

        // Act & Assert
        Assert.True(contact1 == contact2);
    }

    [Fact]
    public void EqualityOperator_DifferentContacts_ShouldReturnFalse()
    {
        // Arrange
        var contact1 = new Contact("John", "Doe", "555-1234", "john@example.com");
        var contact2 = new Contact("Jane", "Smith", "555-5678", "jane@example.com");

        // Act & Assert
        Assert.False(contact1 == contact2);
    }

    [Fact]
    public void EqualityOperator_BothNull_ShouldReturnTrue()
    {
        // Arrange
        Contact? contact1 = null;
        Contact? contact2 = null;

        // Act & Assert
        Assert.True(contact1 == contact2);
    }

    [Fact]
    public void EqualityOperator_LeftNullRightNotNull_ShouldReturnFalse()
    {
        // Arrange
        Contact? contact1 = null;
        var contact2 = new Contact("John", "Doe", "555-1234", "john@example.com");

        // Act & Assert
        Assert.False(contact1 == contact2);
    }

    [Fact]
    public void EqualityOperator_LeftNotNullRightNull_ShouldReturnFalse()
    {
        // Arrange
        var contact1 = new Contact("John", "Doe", "555-1234", "john@example.com");
        Contact? contact2 = null;

        // Act & Assert
        Assert.False(contact1 == contact2);
    }

    [Fact]
    public void InequalityOperator_DifferentContacts_ShouldReturnTrue()
    {
        // Arrange
        var contact1 = new Contact("John", "Doe", "555-1234", "john@example.com");
        var contact2 = new Contact("Jane", "Smith", "555-5678", "jane@example.com");

        // Act & Assert
        Assert.True(contact1 != contact2);
    }

    [Fact]
    public void InequalityOperator_IdenticalContacts_ShouldReturnFalse()
    {
        // Arrange
        var contact1 = new Contact("John", "Doe", "555-1234", "john@example.com");
        var contact2 = new Contact("John", "Doe", "555-1234", "john@example.com");

        // Act & Assert
        Assert.False(contact1 != contact2);
    }

    [Fact]
    public void InequalityOperator_BothNull_ShouldReturnFalse()
    {
        // Arrange
        Contact? contact1 = null;
        Contact? contact2 = null;

        // Act & Assert
        Assert.False(contact1 != contact2);
    }

    #endregion

    #region GetHashCode Tests

    [Fact]
    public void GetHashCode_IdenticalContacts_ShouldReturnSameHashCode()
    {
        // Arrange
        var contact1 = new Contact("John", "Doe", "555-1234", "john@example.com");
        var contact2 = new Contact("John", "Doe", "555-1234", "john@example.com");

        // Act & Assert
        Assert.Equal(contact1.GetHashCode(), contact2.GetHashCode());
    }

    [Fact]
    public void GetHashCode_DifferentContacts_ShouldReturnDifferentHashCodes()
    {
        // Arrange
        var contact1 = new Contact("John", "Doe", "555-1234", "john@example.com");
        var contact2 = new Contact("Jane", "Smith", "555-5678", "jane@example.com");

        // Act & Assert
        Assert.NotEqual(contact1.GetHashCode(), contact2.GetHashCode());
    }

    [Theory]
    [InlineData("", "", "", "")]
    [InlineData("A", "B", "C", "D")]
    [InlineData("Long Name With Spaces", "Long Last Name", "+1-555-123-4567", "very.long.email.address@example.com")]
    public void GetHashCode_SameContactDifferentConstruction_ShouldBeConsistent(string fname, string lname, string phone, string email)
    {
        // Arrange
        var contact1 = new Contact(fname, lname, phone, email);
        var contact2 = new Contact(fname, lname, phone, email);

        // Act & Assert
        Assert.Equal(contact1.GetHashCode(), contact2.GetHashCode());
    }

    [Fact]
    public void GetHashCode_ContactModified_ShouldChangeHashCode()
    {
        // Arrange
        var contact = new Contact("John", "Doe", "555-1234", "john@example.com");
        int originalHashCode = contact.GetHashCode();

        // Act
        contact.SetFName("Jane");
        int newHashCode = contact.GetHashCode();

        // Assert
        Assert.NotEqual(originalHashCode, newHashCode);
    }

    #endregion

    #region Edge Case Tests

    [Fact]
    public void Constructor_WithEmptyStrings_ShouldSetEmptyStrings()
    {
        // Arrange & Act
        var contact = new Contact("", "", "", "");

        // Assert
        Assert.Equal("", contact.GetFName());
        Assert.Equal("", contact.GetLName());
        Assert.Equal("", contact.GetPhone());
        Assert.Equal("", contact.GetEmail());
    }

    [Fact]
    public void Constructor_WithWhitespaceStrings_ShouldPreserveWhitespace()
    {
        // Arrange & Act
        var contact = new Contact("  John  ", "  Doe  ", "  555-1234  ", "  john@example.com  ");

        // Assert
        Assert.Equal("  John  ", contact.GetFName());
        Assert.Equal("  Doe  ", contact.GetLName());
        Assert.Equal("  555-1234  ", contact.GetPhone());
        Assert.Equal("  john@example.com  ", contact.GetEmail());
    }

    [Fact]
    public void SetFName_WithEmptyString_ShouldSetEmptyString()
    {
        // Arrange
        var contact = new Contact("John", "Doe", "555-1234", "john@example.com");

        // Act
        contact.SetFName("");

        // Assert
        Assert.Equal("", contact.GetFName());
    }

    [Fact]
    public void SetFName_WithWhitespace_ShouldSetWhitespace()
    {
        // Arrange
        var contact = new Contact();

        // Act
        contact.SetFName("   ");

        // Assert
        Assert.Equal("   ", contact.GetFName());
    }

    [Fact]
    public void SetPhone_WithSpecialCharacters_ShouldPreserveSpecialCharacters()
    {
        // Arrange
        var contact = new Contact();
        string specialPhone = "+1 (555) 123-4567 ext. 42";

        // Act
        contact.SetPhone(specialPhone);

        // Assert
        Assert.Equal(specialPhone, contact.GetPhone());
    }

    [Fact]
    public void SetEmail_WithComplexEmail_ShouldPreserveEmail()
    {
        // Arrange
        var contact = new Contact();
        string complexEmail = "john.doe+filter@subdomain.example.co.uk";

        // Act
        contact.SetEmail(complexEmail);

        // Assert
        Assert.Equal(complexEmail, contact.GetEmail());
    }

    #endregion

    #region Behavior Tests

    [Fact]
    public void Contact_ShouldBeUsableInDictionaryAsKey()
    {
        // Arrange
        var contact1 = new Contact("John", "Doe", "555-1234", "john@example.com");
        var contact2 = new Contact("John", "Doe", "555-1234", "john@example.com");
        var dictionary = new Dictionary<Contact, string>();

        // Act
        dictionary[contact1] = "Value for contact";
        
        // Assert - Same contact should retrieve same value due to proper hashcode and equals
        Assert.True(dictionary.ContainsKey(contact2));
        Assert.Equal("Value for contact", dictionary[contact2]);
    }

    [Fact]
    public void Contact_ShouldBeUsableInHashSet()
    {
        // Arrange
        var contact1 = new Contact("John", "Doe", "555-1234", "john@example.com");
        var contact2 = new Contact("John", "Doe", "555-1234", "john@example.com");
        var hashSet = new HashSet<Contact>();

        // Act
        hashSet.Add(contact1);
        
        // Assert - HashSet should not allow duplicate based on equality
        Assert.Contains(contact2, hashSet);
    }

    #endregion
}