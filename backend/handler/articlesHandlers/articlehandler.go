package articleshandlers

import (
	config "main.go/config"
)

var (
	logger *config.Logger
)

func InitializeArticleHandler() {
	logger = config.GetLogger("articlehandlers")

	err := config.Init()
	if err != nil {
		logger.Errorf("config initialization error: %v", err)
		return
	}
}