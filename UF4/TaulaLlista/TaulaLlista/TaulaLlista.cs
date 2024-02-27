using System.Text;

namespace ED
{
    public class TaulaLlista
    {
        private object[] dades;
        private int nElements;

        public int Capacitat => nElements;

        public TaulaLlista(int mida)
        {
            dades = new object[mida];
            nElements = 0;
        }

        public TaulaLlista() : this(2)
        {
        }

        public TaulaLlista(TaulaLlista taula)
        {
            dades = new object[taula.dades.Length];
            nElements = taula.nElements;
            for (int i = 0; i < nElements; i++)
            {
                dades[i] = taula.dades[i];
            }
        }

        public int Afegeix(object elem)
        {
            if (elem == null) throw new NullReferenceException();
            if (nElements == dades.Length) DuplicaMida();
            dades[nElements] = elem;
            nElements++;
            return nElements - 1;
        }

        public void AfegeixRang(IEnumerable<object> arrayElements)
        {
            if (arrayElements == null) throw new NullReferenceException();
            foreach (var element in arrayElements)
            {
                if (element != null)
                    Afegeix(element);
            }
        }

        public void Insereix(object element, int position)
        {
            if (position < 0 || position > nElements - 1) throw new IndexOutOfRangeException(nameof(position));
            Afegeix(dades[nElements - 1]);
            for (int i = nElements - 1; i > position; i--)
            {
                dades[i] = dades[i - 1];
            }
            dades[position] = element;
        }

        public void Neteja()
        {
            for (int i = 0; i < nElements; i++)
            {
                dades[i] = null;
            }

            nElements = 0;
        }

        public bool Conté(object elem)
        {
            int i = 0;
            bool contains = false;
            while (!contains && i < nElements)
            {
                if (elem.Equals(dades[i])) contains = true;
                else i++;
            }

            return contains;
        }

        public int IndexDe(object elem)
        {
            int i = 0, index = -1;
            while (index == -1 && i < nElements)
            {
                if (elem.Equals(dades[i])) index = i;
                else i++;
            }

            return index;
        }

        public int UltimIndexDe(object elem)
        {
            int i = nElements, index = -1;
            while (index == -1 && i > 0)
            {
                if (elem.Equals(dades[i])) index = i;
                else i--;
            }

            return index;
        }

        public bool Elimina(object elem)
        {
            int i = 0;
            bool found = false;
            while (!found && i < nElements)
            {
                if (elem.Equals(dades[i]))
                {
                    found = true;
                }
                else i++;
            }

            if (found)
            {
                for (int j = i; j < nElements-1; j++)
                {
                    dades[j] = dades[j + 1];
                }

                dades[nElements - 1] = null;
                nElements--;
            }
            return found;
        }

        public void Inverteix()
        {
            object aux;
            for (int i = 0; i < nElements/2; i++)
            {
                aux = dades[i];
                dades[i] = dades[nElements - 1 - i];
                dades[nElements - 1 - i] = aux;
            }
            //TODO: comment with teacher
            //(dades[i], dades[nElements - 1 - i]) = (dades[nElements - 1 - i], dades[i]);
        }
        public object[] ToArray()
        {
            object[] toReturn = new object[nElements];
            for (int i = 0; i < nElements; i++)
            {
                toReturn[i] = dades[i];
            }
            return toReturn;
        }

        #region Private Methods

        private void DuplicaMida()
        {
            object[] newArray = new object[dades.Length * 2];
            for (int i = 0; i < dades.Length; i++)
            {
                newArray[i] = dades[i];
            }

            dades = newArray;
        }

        
        #endregion

        #region Operators

        public object this[int index]
        {
            get
            {
                if (index < 0 || index > nElements) throw new ArgumentOutOfRangeException(nameof(index));
                return dades[index];
            }
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            StringBuilder toString = new("[");
            for (var index = 0; index < nElements-1; index++)
            {
                var dada = dades[index];
                toString.Append($"{dada},");
            }

            toString.Append(nElements > 0 ? $"{dades[nElements-1]}]" : "]");
            return toString.ToString();
        }

        public override bool Equals(object? obj)
        {
            bool equals;
            if (obj == null) equals = false;
            else if (obj is TaulaLlista) equals = true;
            else equals = false;
            return equals;
        }

        #endregion
    }
}