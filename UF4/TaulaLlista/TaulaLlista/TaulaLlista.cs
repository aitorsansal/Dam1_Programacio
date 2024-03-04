using System.Text;

namespace TL
{
    public class TaulaLlista
    {
        private object[] dades;
        private int nElements;
        private const int MIDA_DEFECTE = 5;

        public int Capacitat => dades.Length;
        public int NElements => nElements;

        public TaulaLlista(int mida)
        {
            dades = new object[mida];
            nElements = 0;
        }

        public TaulaLlista() : this(MIDA_DEFECTE)
        { }

        public TaulaLlista(TaulaLlista taula)
        {
            if (taula is null) throw new NullReferenceException("La taula a copiar no pot ser nul·la");
            dades = new object[taula.dades.Length];
            nElements = taula.nElements;
            for (int i = 0; i < nElements; i++) { dades[i] = taula.dades[i]; }
        }

        public int Afegeix(object elem)
        {
            if (elem is null) throw new NullReferenceException();
            if (nElements == Capacitat) DuplicaMida();
            dades[nElements] = elem;
            return nElements++;
        }

        public void AfegeixRang(IEnumerable<object> arrayElements)
        {
            if (arrayElements is null) throw new NullReferenceException(nameof(arrayElements));
            foreach (var element in arrayElements) Afegeix(element);
        }
        public void Neteja()
        {
            for (int i = 0; i < nElements; i++)
                dades[i] = default;

            nElements = 0;
        }
        public void Insereix(object element, int position)
        {
            if (element is null) throw new ArgumentNullException(nameof(element));
            if (position < 0 || position > nElements - 1) throw new IndexOutOfRangeException(nameof(position));
            Afegeix(element);
            object aux;
            for (int i = nElements - 1; i >= position; i--)
            {
                aux = dades[i];
                dades[i] = dades[i - 1];
                dades[i - 1] = aux;
            }
        }

        public object EliminaA(int pos)
        {
            object o;
            if (pos < 0 || pos >= nElements) throw new IndexOutOfRangeException("index out of range");

            o = dades[pos];
            for (int i = pos; i <= nElements - 2; i++)
            {
                dades[i] = dades[i + 1];
            }

            dades[nElements - 1] = default;
            nElements--;
            return o;
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

        public bool Conte(object elem)
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
            int i = 0, index = 0;
            bool found = false;
            while (!found && i < nElements)
            {
                found = Equals(dades[i], elem);
                if (!found) i++;
            }

            if (!found) index = -1;
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

        public void Inverteix()
        {
            object aux;
            for (int i = 0; i < nElements/2; i++)
            {
                aux = dades[i];
                dades[i] = dades[nElements - 1 - i];
                dades[nElements - 1 - i] = aux;
            }
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
            for (int i = 0; i < Capacitat; i++) { newArray[i] = dades[i]; }
            dades = newArray;
        }

        
        #endregion

        #region Operators

        public object this[int index]
        {
            get
            {
                if (index < 0 || index > nElements) throw new IndexOutOfRangeException($"{index} out of range [0,{nElements - 1}]");
                return dades[index];
            }
            set
            {
                if (index < nElements || index > 0)
                    throw new IndexOutOfRangeException($"{index} out of range [0,{nElements - 1}]");
                dades[index] = value ?? throw new ArgumentNullException(nameof(value));
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
            bool equals = true;
            if (obj == null) equals = false;
            else if (obj is TaulaLlista llista)
            {
                TaulaLlista entrada = new(llista);
                if (nElements != entrada.nElements) equals = false;
                else
                {
                    int i = 0;
                    while (equals && i<nElements)
                    {
                        equals = dades[i].Equals(entrada.dades[i]);
                        i++;
                    }
                }
            }
            else equals = false;
            return equals;
        }
        #endregion
    }
}