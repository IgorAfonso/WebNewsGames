package articleshandlers

import (
	"fmt"

	"github.com/gin-gonic/gin"
)

func ListArticles(ctx *gin.Context) {
	fmt.Println("FUNCIONOU ARTIGO")
}