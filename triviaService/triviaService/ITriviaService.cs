using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace triviaService {
    [ServiceContract]
    public interface ITriviaService {
        [OperationContract]
        bool SaveScore(Score score);

        [OperationContract]
        bool DeleteScore(int id);

        [OperationContract]
        bool UpdateScore(Score score);

        [OperationContract]
        List<Score> SelectAll();

        [OperationContract]
        Score GetUserScore(int user_id);

        [OperationContract]
        List<Score> GetTop10Score();
    }
}
