
namespace ClassLibrary1
{
    public class Class1
    {
        private
        Dictionary<string, int> parse(IEnumerable<string> fContent)
        {
            // в мапу (словарь) запишем слова и их количество
            Dictionary<string, int> word_num_pairs = new Dictionary<string, int>();
            //в массив запишем все символы, которые не могут войти в состав слова (возможно, сюда надо что-то еще добавить)
            char[] delimeters = { ')', '(', ']', '[', '{', '}', ' ', ',', '.', '!', '?', ':', ';', '-', '—' };

            foreach (var str in fContent)
            {
                // в цикле проходим по всем листам, сплитим строки файла по указанным символам.
                // Если слова нет в словаре, то добавляем его туда. Если есть, то +1 к счетчику этого слова
                var words = str.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (word_num_pairs.ContainsKey(word) == false)
                    {
                        word_num_pairs.Add(word, 1);
                    }
                    else
                    {
                        word_num_pairs[word]++;
                    }
                }
            }
            return word_num_pairs;
        }
    }
}