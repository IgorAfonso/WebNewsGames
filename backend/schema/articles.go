package schema

import (
	"github.com/google/uuid"
	"gorm.io/gorm"
)

type Articles struct {
	gorm.Model
	ID         uuid.UUID
	Title      string
	Content    string
}