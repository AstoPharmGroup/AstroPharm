using AstroPharm.Domain.Commons;
using AstroPharm.Domain.Entities;
using AstroPharm.Domain.Entities.Users;

public class RefreshToken : Auditable
{
        public long Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
}