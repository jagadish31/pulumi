// Copyright 2016 Pulumi, Inc. All rights reserved.

package core

import (
	"github.com/pulumi/coconut/pkg/diag"
)

// Phase represents a compiler phase.
type Phase interface {
	// Diag fetches the diagnostics sink used by this compiler pass.
	Diag() diag.Sink
}
