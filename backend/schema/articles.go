package schema

import (
	"time"

	"github.com/google/uuid"
)

type Articles struct {
	ID         uuid.UUID
	Title      string
	CreateDate time.Time
	UpdateDate time.Time
	DeleteDate time.Time
	Content    string
}