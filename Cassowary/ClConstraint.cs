/*
  Cassowary.net: an incremental constraint solver for .NET
  (http://lumumba.uhasselt.be/jo/projects/cassowary.net/)
    
  Copyright (C) 2005-2006  Jo Vermeulen (jo.vermeulen@uhasselt.be)
    
  This program is free software; you can redistribute it and/or
  modify it under the terms of the GNU Lesser General Public License
  as published by the Free Software Foundation; either version 2.1
  of  the License, or (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU Lesser General Public License for more details.

  You should have received a copy of the GNU Lesser General Public License
  along with this program; if not, write to the Free Software
  Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
*/

namespace Cassowary
{
    public abstract class ClConstraint
    {
        protected ClConstraint(ClStrength strength, double weight)
        {
            _strength = strength;
            Weight = weight;
        }

        protected ClConstraint(ClStrength strength)
        {
            _strength = strength;
            Weight = 1.0;
        }

        protected ClConstraint()
        {
            _strength = ClStrength.Required;
            Weight = 1.0;
        }

        public abstract ClLinearExpression Expression { get; }

        public virtual bool IsEditConstraint
        {
            get { return false; }
        }

        public virtual bool IsInequality
        {
            get { return false; }
        }

        public virtual bool IsRequired
        {
            get { return _strength.IsRequired; }
        }

        public virtual bool IsStayConstraint
        {
            get { return false; }
        }

        public ClStrength Strength
        {
            get { return _strength; }
            set { _strength = value; }
        }

        public double Weight { get; private set; }

        public override string ToString()
        {
            // two curly brackets escape the format, so use three to surround
            // a format expression in brackets!
            //
            // example output: weak:[0,0,1] {1} (23 + -1*[update.height:23]
            return string.Format("{0} {{{1}}} ({2}", Strength, Weight, Expression);
        }

        private ClStrength _strength;
    }
}