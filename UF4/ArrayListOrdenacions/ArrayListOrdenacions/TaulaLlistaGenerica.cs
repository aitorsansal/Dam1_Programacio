using System.Text;

namespace TL
{
    public class TaulaLlistaGenerica<T>
    {
        private T[] dades;
        private int nElements;
        private const int MIDA_DEFECTE = 5;

        public int Capacitat => dades.Length;
        public int NElements => nElements;

        public TaulaLlistaGenerica(int mida)
        {
            dades = new T[mida];
            nElements = 0;
        }

        public TaulaLlistaGenerica() : this(MIDA_DEFECTE)
        { }

        public TaulaLlistaGenerica(TaulaLlistaGenerica<T> taula)
        {
            if (taula is null) throw new NullReferenceException("La taula a copiar no pot ser nul·la");
            dades = new T[taula.dades.Length];
            nElements = taula.nElements;
            for (int i = 0; i < nElements; i++) { dades[i] = taula.dades[i]; }
        }

        public int Afegeix(T elem)
        {
            if (elem is null) throw new NullReferenceException();
            if (nElements == Capacitat) DuplicaMida();
            dades[nElements] = elem;
            return nElements++;
        }

        public void AfegeixRang(IEnumerable<T> arrayElements)
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
        public void Insereix(T element, int position)
        {
            if (element is null) throw new ArgumentNullException(nameof(element));
            if (position < 0 || position > nElements - 1) throw new IndexOutOfRangeException(nameof(position));
            Afegeix(element);
            T aux;
            for (int i = nElements - 1; i >= position; i--)
            {
                aux = dades[i];
                dades[i] = dades[i - 1];
                dades[i - 1] = aux;
            }
        }

        public T EliminaA(int pos)
        {
            T obj;
            if (pos < 0 || pos >= nElements) throw new IndexOutOfRangeException("index out of range");

            obj = dades[pos];
            for (int i = pos; i <= nElements - 2; i++)
            {
                dades[i] = dades[i + 1];
            }

            dades[nElements - 1] = default;
            nElements--;
            return obj;
        }
        public bool Elimina(T elem)
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

                dades[nElements - 1] = default;
                nElements--;
            }
            return found;
        }

        public bool Conte(T elem)
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

        public int IndexDe(T elem)
        {
            int index = 0;
            bool found = false;
            while (!found && index < nElements)
            {
                found = Equals(dades[index], elem);
                if (!found) index++;
            }

            if (!found) index = -1;
            return index;
        }

        public int UltimIndexDe(T elem)
        {
            int index = nElements;
            bool found = false;
            while (!found && index > 0)
            {
                found = elem.Equals(dades[index]);
                if(!found) index--;
            }

            if (!found) index = -1;
            return index;
        }

        public void Inverteix()
        {
            T aux;
            for (int i = 0; i < nElements/2; i++)
            {
                aux = dades[i];
                dades[i] = dades[nElements - 1 - i];
                dades[nElements - 1 - i] = aux;
            }
        }
        public T[] ToArray()
        {
            T[] toReturn = new T[nElements];
            for (int i = 0; i < nElements; i++)
            {
                toReturn[i] = dades[i];
            }
            return toReturn;
        }

        public T Minim()
        {
            if (nElements == 0) throw new Exception("LLista buida. No hi ha minim");
            T valorMinim = dades[0];
            IComparable<T> valorActual;
            if (valorMinim is IComparable<T>)
            {
                for (int i = 0; i < nElements; i++)
                {
                    valorActual = dades[i] as IComparable<T>;
                    if (valorActual.CompareTo(valorMinim) < 0) valorMinim = dades[i];
                }
            }
            else throw new Exception(valorMinim.GetType() + "no és IComparable");

            return valorMinim;
        }
        public T PrimerMenorQue(T element)
        {
            if(dades[0] is not IComparable<T> || element is not IComparable<T>) throw new Exception("Els elements no son comparables");
            if (nElements == 0) throw new Exception("La taula llista està buida");
            T elementPetit = default(T);
            bool found = false;
            for (int i = 0; i < dades.Length && !found; i++)
            {
                if ((dades[i] as IComparable<T>).CompareTo(element) < 0)
                {
                    elementPetit = dades[i];
                    found = true;
                }
            }

            return elementPetit;
        }


        public void Sort()
        {
            if (dades[0] is not IComparable<T>) throw new Exception("Els elements no son comparables");
            T[] array = ToArray();
            Array.Sort(array);
            for (var index = 0; index < array.Length; index++)
            {
                dades[index] = array[index];
            }
        }
        
        public void Sort(IComparer<T> comparer)
        {
            if (dades[0] is not IComparable<T>) throw new Exception("Els elements no son comparables");
            T[] array = ToArray();
            Array.Sort(array, comparer);
            for (var index = 0; index < array.Length; index++)
            {
                dades[index] = array[index];
            }
        }

        #region Private Methods

        private void DuplicaMida()
        {
            T[] newArray = new T[dades.Length * 2];
            for (int i = 0; i < Capacitat; i++) { newArray[i] = dades[i]; }
            dades = newArray;
        }

        
        #endregion

        #region Operators

        public T this[int index]
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
            if (this is not null) return obj is null;
            if (obj is not TaulaLlistaGenerica<T>) return false;
            return Equals(obj as TaulaLlistaGenerica<T>);
        }

        public bool Equals(T? obj)
        {
            bool equals = true;
            if (obj is null) equals = this is null;
            else if (obj is TaulaLlistaGenerica<T> llista)
            {
                TaulaLlistaGenerica<T> entrada = new(llista);
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