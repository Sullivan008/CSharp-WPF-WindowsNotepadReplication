using System;
using System.IO;
using Application.Client.Cache.DataModels;
using Application.Client.Cache.DataModels.Enums;
using Application.Client.Cache.Infrastructure.Repository.Interfaces;
using Application.Client.Services.Interfaces;

namespace Application.Client.Services
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
                DocInfoDataModel docInfoData = GetDocInfoData();

                return docInfoData.FilePath;
            }
        }

        public string UsedFileNameWithExtension
        {
            get
            {
                DocInfoDataModel docInfoData = GetDocInfoData();

                if (!string.IsNullOrWhiteSpace(docInfoData.FilePath))
                {
                    return Path.GetFileName(docInfoData.FilePath);
                }

                return $"{DEFAULT_FILE_NAME}.{DEFAULT_FILE_EXTENSION}";
            }
        }

        public string UsedFileNameWithoutExtension
        {
            get
            {
                DocInfoDataModel docInfoData = GetDocInfoData();

                if (!string.IsNullOrWhiteSpace(docInfoData.FilePath))
                {
                    return Path.GetFileNameWithoutExtension(docInfoData.FilePath);
                }

                return $"{DEFAULT_FILE_NAME}";
            }
        }

        public bool IsModifiedDocument
        {
            get
            {
                DocInfoDataModel docInfoData = GetDocInfoData();

                return docInfoData.DocumentState == DocumentState.Modified;
            }
        }

        public bool IsOpenedDocument
        {
            get
            {
                DocInfoDataModel docInfoData = GetDocInfoData();

                return !string.IsNullOrWhiteSpace(docInfoData.FilePath);
            }
        }

        public void SetDefaultDocInfo()
        {
            _docInfoCacheRepository.SetItem(new DocInfoDataModel
            {
                FilePath = string.Empty,
                DocumentState = DocumentState.Unmodified
            });
        }

        public void SetFilePath(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), "The value cannot be null!");
            }

            DocInfoDataModel docInfoData = GetDocInfoData();
            docInfoData.FilePath = filePath;

            SetDocInfoData(docInfoData);
        }

        public void SetModifiedDocumentState()
        {
            DocInfoDataModel docInfoData = GetDocInfoData();
            docInfoData.DocumentState = DocumentState.Modified;

            SetDocInfoData(docInfoData);
        }

        public void SetUnmodifiedDocumentState()
        {
            DocInfoDataModel docInfoData = GetDocInfoData();
            docInfoData.DocumentState = DocumentState.Unmodified;

            SetDocInfoData(docInfoData);
        }

        private DocInfoDataModel GetDocInfoData()
        {
            DocInfoDataModel docInfoData = _docInfoCacheRepository.GetItem();

            if (docInfoData == null)
            {
                return new DocInfoDataModel
                {
                    FilePath = string.Empty,
                    DocumentState = DocumentState.Unmodified
                };
            }

            return docInfoData;
        }

        private void SetDocInfoData(DocInfoDataModel docInfoData)
        {
            _docInfoCacheRepository.SetItem(docInfoData);
        }
    }
}
