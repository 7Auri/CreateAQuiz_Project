using CreateAQuiz.Business.Abstract;
using CreateAQuiz.Business.Constants;
using CreateAQuiz.Core.Utilities.Result;
using CreateAQuiz.DataAccess.Abstract;
using CreateAQuiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.ServiceModel.Syndication;
using Newtonsoft.Json;
using CreateAQuiz.Core.Utilities.RSS;
using CreateAQuiz.Core.Utilities.Extension;

namespace CreateAQuiz.Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public IResult Add(Article article)
        {
            _articleDal.Add(article);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public IResult Delete(Article article)
        {
            _articleDal.Delete(article);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public IDataResult<List<Article>> GetAll()
        {
            return new SuccessDataResult<List<Article>>(_articleDal.GetAll(), Messages.SuccessListed);
        }

        public IDataResult<Article> GetById(int articleId)
        {
            return new SuccessDataResult<Article>(_articleDal.Get(x => x.Id == articleId), Messages.SuccessListed);
        }

        public IResult SyncArticleWithWired()
        {
            try
            {
                RssReader rssReader = new RssReader(@"https://www.wired.com/feed/rss");
                SyndicationFeed feed = rssReader.Read();

                DateTime lastAddedArticleDate = _articleDal.LastUpdateDate();
                TimeSpan diff = lastAddedArticleDate - feed.LastUpdatedTime.UtcDateTime;

                if (diff.TotalSeconds == 0)
                {
                    return new Result(true);
                }


                List<Article> contents = new List<Article>();

                foreach (var item in feed.Items)
                {
                    Article entity = new Article()
                    {
                        Description = item.Summary.Text,
                        Detail = item.ToJson(false),
                        PublishArticleDate = feed.LastUpdatedTime.UtcDateTime,
                        PublishRssDate = item.PublishDate.UtcDateTime,
                        Title = item.Title.Text,

                    };
                    contents.Add(entity);
                }

                foreach (var item in contents)
                {
                    _articleDal.Add(item);
                }
                return new Result(true);
            }
            catch (System.Exception e)
            {

                return new Result(false, e.ToString());
            }
        }

        public IResult Update(Article article)
        {
            _articleDal.Update(article);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
