using System;
using System.IO;
using Application.Client.Cache.DataModels.DocInfo;
using Application.Client.Cache.DataModels.DocInfo.Enums;
using Application.Client.Cache.Infrastructure.Repository.Interfaces;
using Application.Client.Services.DocInfo.Interfaces;

namespace Application.Client.Services.DocInfo
{
    public class DocInfoService : IDocInfoService
    {
        private const string DEFAULT_FILE_NAME = "Unnamed";

        private const string DEFAULT_FILE_EXTENSION = "txt";

        private readonly ICacheRepository<DocInfoDataModel> _docInfoCacheRepository;

        public DocInfoService(ICacheRepository<DocInfoDataModel> docInfoCacheRepository)
        {
            _docInfoCacheRepository = docInfoCacheRepository;
        }

        public string UsedFilePath
        {
            get
            {
                DocInfoDataModel docInfoData = _docInfoCacheRepository.GetItem();

                return docInfoData.FileInfo.FilePath;
            }
        }

        public string UsedFileNameWithExtension
        {
            get
            {
                DocInfoDataModel docInfoData = _docInfoCacheRepository.GetItem();

                if (!string.IsNullOrWhiteSpace(docInfoData.FileInfo.FilePath))
                {
                    return Path.GetFileName(docInfoData.FileInfo.FilePath);
                }

                return $"{DEFAULT_FILE_NAME}.{DEFAULT_FILE_EXTENSION}";
            }
        }

        public string UsedFileNameWithoutExtension
        {
            get
            {
                DocInfoDataModel docInfoData = _docInfoCacheRepository.GetItem();

                if (!string.IsNullOrWhiteSpace(docInfoData.FileInfo.FilePath))
                {
                    return Path.GetFileNameWithoutExtension(docInfoData.FileInfo.FilePath);
                }

                return $"{DEFAULT_FILE_NAME}";
            }
        }

        public bool IsModifiedDocument
        {
            get
            {
                DocInfoDataModel docInfoData = _docInfoCacheRepository.GetItem();

                return docInfoData.DocumentState == DocumentState.Modified;
            }
        }

        public bool IsOpenedDocument
        {
            get
            {
                DocInfoDataModel docInfoData = _docInfoCacheRepository.GetItem();

                return !string.IsNullOrWhiteSpace(docInfoData.FileInfo.FilePath);
            }
        }

        public int ContentLength
        {
            get
            {
                DocInfoDataModel docInfoData = _docInfoCacheRepository.GetItem();

                return docInfoData.ContentInfo.Length;
            }
        }

        public int ContentLines
        {
            get
            {
                DocInfoDataModel docInfoData = _docInfoCacheRepository.GetItem();

                return docInfoData.ContentInfo.Lines;
            }
        }

        public void SetDefaultDocInfo()
        {
            _docInfoCacheRepository.SetItem(new DocInfoDataModel
            {
                FileInfo = new FileInfoDataModel(),
                ContentInfo = new ContentInfoDataModel(),
                DocumentState = DocumentState.Unmodified
            });
        }

        public void SetFilePath(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), "The value cannot be null!");
            }

            DocInfoDataModel docInfoData = _docInfoCacheRepository.GetItem();
            docInfoData.FileInfo.FilePath = filePath;

            _docInfoCacheRepository.SetItem(docInfoData);
        }

        public void SetModifiedDocumentState()
        {
            DocInfoDataModel docInfoData = _docInfoCacheRepository.GetItem();
            docInfoData.DocumentState = DocumentState.Modified;

            _docInfoCacheRepository.SetItem(docInfoData);
        }

        public void SetUnmodifiedDocumentState()
        {
            DocInfoDataModel docInfoData = _docInfoCacheRepository.GetItem();
            docInfoData.DocumentState = DocumentState.Unmodified;

            _docInfoCacheRepository.SetItem(docInfoData);
        }

        public void SetContentLength(int contentLength)
        {
            DocInfoDataModel docInfoData = _docInfoCacheRepository.GetItem();
            docInfoData.ContentInfo.Length = contentLength;

            _docInfoCacheRepository.SetItem(docInfoData);
        }

        public void SetContentLines(int contentLines)
        {
            DocInfoDataModel docInfoData = _docInfoCacheRepository.GetItem();
            docInfoData.ContentInfo.Lines = contentLines;

            _docInfoCacheRepository.SetItem(docInfoData);
        }
    }
}
