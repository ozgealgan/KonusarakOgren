using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonusarakOgren.Business.Proxies.Interfaces;
using KonusarakOgren.Business.Services.Interfaces;
using KonusarakOgren.Data.Entities;
using KonusarakOgren.Data.Repositories;
using KonusarakOgren.Data.Repositories.Interfaces;
using KonusarakOgren.Infrastructure.Enum;
using KonusarakOgren.Models;
using KonusarakOgren.Models.Responses;

namespace KonusarakOgren.Business.Services
{
    public class ExamService : IExamService
    {
        private readonly IWiredApiProxy _wiredApiProxy;
        private readonly IExamRepository _examRepository;
        private readonly IQuestionRepository _questionRepository;

        public ExamService(IWiredApiProxy wiredApiProxy, 
            IExamRepository examRepository,
            IQuestionRepository questionRepository)
        {
            _wiredApiProxy = wiredApiProxy;
            _examRepository = examRepository;
            _questionRepository = questionRepository;
        }

        public async Task<List<Article>> GetWiredArticles()
        {
            var response = await _wiredApiProxy.GetWiredArticles();

            return response.Articles.Take(5).ToList();
        }

        public void CreateExam(ExamCreateModel model)
        {
            Exam exam = new Exam();
            exam.Content = model.ArticleContent;
            exam.Title = model.ArticleTitle;
            exam.CreateDate = DateTime.Now.ToString();
            
            foreach (var questionModel in model.Questions)
            {
                Question question = new Question();
                question.QuestionContent = questionModel.Content;

                Option optionA = GetOption(questionModel, QuestionOptionsType.A);
                Option optionB = GetOption(questionModel, QuestionOptionsType.B);
                Option optionC = GetOption(questionModel, QuestionOptionsType.C);
                Option optionD = GetOption(questionModel, QuestionOptionsType.D);

                question.Options.Add(optionA);
                question.Options.Add(optionB);
                question.Options.Add(optionC);
                question.Options.Add(optionD);

                exam.Questions.Add(question);
            }

            _examRepository.CreateExam(exam);
        }

        public List<Exam> GetExams()
        {
            return _examRepository.GetExams();
        }

        public Exam GetExam(int id)
        {
            return _examRepository.GetExam(id);
        }

        public List<QuestionAnswerResponse> CheckQuestionAnswers(List<QuestionAnswerRequest> request)
        {
            var response = new List<QuestionAnswerResponse>();

            foreach (var questionAnswer in request)
            {
                var correctAnswer = _questionRepository.CheckQuestionAnswer(questionAnswer);

                response.Add(correctAnswer);
            }

            return response;
        }

        public void DeleteExam(int examId)
        {
            _examRepository.DeleteExam(examId);
        }

        private Option GetOption(ExamQuestionModel model, QuestionOptionsType type)
        {
            Option option = new Option
            {
                OptionContent = GetOptionContent(model, type),
                OptionType = type,
                IsCorrectOption = type == model.CorrectAnswer
            };

            return option;
        }

        private string GetOptionContent(ExamQuestionModel model, QuestionOptionsType type)
        {
            if(type == QuestionOptionsType.A)
            {
                return model.OptionA;
            } else if(type == QuestionOptionsType.B)
            {
                return model.OptionB;
            } else if (type == QuestionOptionsType.C)
            {
                return model.OptionC;
            }else
            {
                return model.OptionD;
            }
        }
    }
}
