package articleshandlers

import (
	"fmt"

	"github.com/gin-gonic/gin"
)

func GetArticle(ctx *gin.Context) {
	fmt.Println("FUNCIONOU ARTIGO")
}