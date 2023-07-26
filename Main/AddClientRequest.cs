using System.ComponentModel.DataAnnotations;

namespace Main.Client.Requests
{
    /// <summary>
    /// Represents a client creation request
    /// </summary>
    public class AddClientRequest
    {
        /// <summary>
        /// The Client's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Client's Email
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// The Client's CC
        /// </summary>
        [CreditCard]
        public int CreditCard { get; set; }
    }
}