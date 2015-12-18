using System;

namespace EcuCommunication
{
    public abstract class Request
    {
        protected byte[] requestBuffer;
        protected byte[] replyBuffer;

        /// <summary>
        /// Последнее состояние запроса
        /// </summary>
        public bool Valid { get; protected set; }
        
        /// <summary>
        /// Получить данные запроса для записи в порт
        /// </summary>
        /// <returns></returns>
        public byte[] GetRequest()
        {
            return requestBuffer;
        }

        /// <summary>
        /// Установить ответ ЭБУ на запрос
        /// </summary>
        /// <param name="reply"></param>
        public void SetReply(ref byte[] reply)
        {
            replyBuffer = reply;
            DoExecute(EventArgs.Empty);
        }

        /// <summary>
        /// Запрос выполнен
        /// </summary>
        public bool Executed { get; protected set; }
        
        /// <summary>
        /// Сброс состояния "запрос выполнен"
        /// </summary>
        public void ResetExecuted()
        {
            Executed = false;
        }

        protected virtual void DoExecute(EventArgs e)
        {
            Executed = true;
            Valid = false;
        }

        /// <summary>
        /// Проверка ответа на запрос
        /// </summary>
        /// <returns></returns>
        public abstract bool Test();
    }
}
