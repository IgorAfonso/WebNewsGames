package articleshandlers

import (
	"github.com/gin-gonic/gin"
)

func CreateArticle(ctx *gin.Context) {
	request := &CreateArticleRequest{}

	ctx.BindJSON(&request)
}