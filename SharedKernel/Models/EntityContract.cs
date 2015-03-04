using System.Collections.Generic;
using Models.Core;

namespace SharedKernel.Models
{
    public class EntityContract<TRules, TId> : Entity<TId>
    {
        private HashSet<BrokenRoles<TRules>> BrokenRoles = new HashSet<BrokenRoles<TRules>>();
        public HashSet<BrokenRoles<TRules>> BrokenRules
        {
            get
            {
                return BrokenRoles;
            }
        }

        public void AddBrokenRule(TRules brokenrule, string message)
        {
            this.BrokenRoles.Add(new BrokenRoles<TRules>(brokenrule, message));
        }

        public virtual bool IsValid
        {
            get { return BrokenRoles.Count == 0; }
        }
    }
}
