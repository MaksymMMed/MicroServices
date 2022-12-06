using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObject
{
    public class Post
    {
        public Post(String PostName, DateTime Entry)
        {
            if (!IsValidName(PostName))
            {
                throw new ArgumentException("Post Name can't be empty or larger than 50 symbols");
            }
            if (!IsValidEntry(Entry))
            {
                throw new ArgumentException("Entry time can't be future");
            }
            this.PostName = PostName;
            this.Entry = Entry;
        }

        public String PostName { get; }
        public DateTime Entry { get; }

        public static Boolean IsValidName(String PostName)
        {
            return PostName != null && PostName.Length <= 50;
        }

        public static Boolean IsValidEntry(DateTime Entry)
        {
            return Entry <= DateTime.Now;
        }

        public override Boolean Equals(Object obj)
        {
            return obj is Post other && PostName == other.PostName;
        }

        public override Int32 GetHashCode()
        {
            return HashCode.Combine(PostName, Entry);
        }
    }
}
