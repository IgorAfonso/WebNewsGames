package articleshandlers

import (
	"github.com/gin-gonic/gin"
)

func CreateArticle(ctx *gin.Context) {
	request := &CreateArticleRequest{}

	ctx.BindJSON(&request)


	if err := request.CreateArticleValidations(); err != nil {
		logger.Errorf("validation error: %+v", err.Error())
		//sendErr(ctx, http.StatusBadRequest, err.Error())
		return
	}
}